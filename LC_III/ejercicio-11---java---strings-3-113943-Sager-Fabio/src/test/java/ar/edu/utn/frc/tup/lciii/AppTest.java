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
        final String testString = "hello" + System.lineSeparator() + "java" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("9" + System.lineSeparator() +
                "No" + System.lineSeparator() +
                "Hello Java" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase2() {
        final String testString = "hello" + System.lineSeparator() + "world" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("10" + System.lineSeparator() +
                        "No" + System.lineSeparator() +
                        "Hello World" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase3() {
        final String testString = "universidad" + System.lineSeparator() + "tecnologica" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("22" + System.lineSeparator() +
                        "Yes" + System.lineSeparator() +
                        "Universidad Tecnologica" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase4() {
        final String testString = "tecnicatura" + System.lineSeparator() + "programacion" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("23" + System.lineSeparator() +
                        "Yes" + System.lineSeparator() +
                        "Tecnicatura Programacion" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase5() {
        final String testString = "universo" + System.lineSeparator() + "universal" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("17" + System.lineSeparator() +
                        "Yes" + System.lineSeparator() +
                        "Universo Universal" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase6() {
        final String testString = "tecnologia" + System.lineSeparator() + "tecnologica" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("21" + System.lineSeparator() +
                        "No" + System.lineSeparator() +
                        "Tecnologia Tecnologica" + System.lineSeparator()
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
