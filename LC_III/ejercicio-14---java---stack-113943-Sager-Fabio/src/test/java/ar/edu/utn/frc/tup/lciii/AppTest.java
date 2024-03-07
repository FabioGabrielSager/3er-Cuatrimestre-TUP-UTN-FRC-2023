package ar.edu.utn.frc.tup.lciii;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.io.PrintStream;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class AppTest {

    private final InputStream systemIn = System.in;
    private final PrintStream systemOut = System.out;

    private ByteArrayInputStream testIn;
    private ByteArrayOutputStream testOut;

    @BeforeEach
    public void setUpOutput() {
        testOut = new ByteArrayOutputStream();
        System.setOut(new PrintStream(testOut));
    }

    @AfterEach
    public void restoreSystemInputOutput() {
        System.setIn(systemIn);
        System.setOut(systemOut);
    }

    @Test
    public void testCase1() {
        final String testString = "{}()" + System.lineSeparator() +
                "({()})" + System.lineSeparator() +
                "{}(" + System.lineSeparator() +
                "[]" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("true" + System.lineSeparator() +
                        "true" + System.lineSeparator() +
                        "false" + System.lineSeparator() +
                        "true" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase2() {
        final String testString = "{[({[()]})]}" + System.lineSeparator() +
                "([{([{}])}])" + System.lineSeparator() +
                "{}[]()" + System.lineSeparator() +
                "{}" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("true" + System.lineSeparator() +
                        "true" + System.lineSeparator() +
                        "true" + System.lineSeparator() +
                        "true" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase3() {
        final String testString = "{[({[())]})]}" + System.lineSeparator() +
                "([{([{}}])}])" + System.lineSeparator() +
                "{}}[]]())" + System.lineSeparator() +
                "{}}" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("false" + System.lineSeparator() +
                        "false" + System.lineSeparator() +
                        "false" + System.lineSeparator() +
                        "false" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase4() {
        final String testString = "{[()]}{[()]}" + System.lineSeparator() +
                "[()()()()()()()()[][][][][][][][]{}{}{}{}{}{}{}]" + System.lineSeparator() +
                "{[{[{[{[{[{[{[{[{[{[{[{[{[{[{[{[{[]}]}]}]}]}]}]}]}]}]}]}]}]}]}]}]}]}" + System.lineSeparator() +
                "{}" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("true" + System.lineSeparator() +
                        "true" + System.lineSeparator() +
                        "true" + System.lineSeparator() +
                        "true" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase5() {
        final String testString = "{[()]}({[()]}{[()]}){[()]}" + System.lineSeparator() +
                "[()()()()()()()()[][][][][]][][]{}{}{}{}{}{}{}]" + System.lineSeparator() +
                "{[{[{[{[{[{[{[{[{[{[{[{[{[{[{[{[{[]}]}]}]}]}]}]}]}]}]}]}]}]}]}]}]}]]" + System.lineSeparator() +
                "(){]" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("true" + System.lineSeparator() +
                        "false" + System.lineSeparator() +
                        "false" + System.lineSeparator() +
                        "false" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase6() {
        final String testString = ")(" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("false" + System.lineSeparator()
                , getOutput());
    }

    private void provideInput(String data) {
        testIn = new ByteArrayInputStream(data.getBytes());
        System.setIn(testIn);
    }

    private String getOutput() {
        return testOut.toString();
    }
}
