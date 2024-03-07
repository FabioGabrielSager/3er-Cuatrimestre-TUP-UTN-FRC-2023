package ar.edu.utn.frc.tup.lciii;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.io.PrintStream;

import static org.junit.jupiter.api.Assertions.*;

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
    @DisplayName("Este es el test 1")
    public void testCase1() {
        final String testString = "Helloworld" + System.lineSeparator() +
                "3 7" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("lowo" + System.lineSeparator(), getOutput());
    }

    @Test
    public void testCase2() {
        final String testString = "HellooWorld" + System.lineSeparator() +
                "3 7" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("looW" + System.lineSeparator(), getOutput());
    }

    @Test
    public void testCase3() {
        final String testString = "HelloWorld" + System.lineSeparator() +
                "0 10" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("HelloWorld" + System.lineSeparator(), getOutput());
    }

    @Test
    public void testCase4() {
        final String testString = "HelloWorld" + System.lineSeparator() +
                "0 1" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("H" + System.lineSeparator(), getOutput());
    }

    @Test
    public void testCase5() {
        final String testString = "HelloWorld" + System.lineSeparator() +
                "9 10" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("d" + System.lineSeparator(), getOutput());
    }

    @Test
    public void testCase6() {
        final String testString = "HelloWorld" + System.lineSeparator() +
                "0 0" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("" + System.lineSeparator(), getOutput());
    }

    @Test
    public void testCase7() {
        final String testString = "HelloWorld" + System.lineSeparator() +
                "10 10" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("" + System.lineSeparator(), getOutput());
    }

    private void provideInput(String data) {
        testIn = new ByteArrayInputStream(data.getBytes());
        System.setIn(testIn);
    }

    private String getOutput() {
        return testOut.toString();
    }
}
