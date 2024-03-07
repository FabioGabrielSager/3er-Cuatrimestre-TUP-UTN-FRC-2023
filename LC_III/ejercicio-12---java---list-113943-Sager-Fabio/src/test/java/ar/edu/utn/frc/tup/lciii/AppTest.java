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
        final String testString = "5" + System.lineSeparator() +
                "12 0 1 78 12" + System.lineSeparator() +
                "2" + System.lineSeparator() +
                "Insert" + System.lineSeparator() +
                "5 23" + System.lineSeparator() +
                "Delete" + System.lineSeparator() +
                "0" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("0 1 78 12 23" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase2() {
        final String testString = "10" + System.lineSeparator() +
                "12 0 1 78 12 12 0 1 78 12" + System.lineSeparator() +
                "2" + System.lineSeparator() +
                "Insert" + System.lineSeparator() +
                "10 23" + System.lineSeparator() +
                "Delete" + System.lineSeparator() +
                "0" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("0 1 78 12 12 0 1 78 12 23" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase3() {
        final String testString = "2" + System.lineSeparator() +
                "12 0" + System.lineSeparator() +
                "2" + System.lineSeparator() +
                "Delete" + System.lineSeparator() +
                "0" + System.lineSeparator() +
                "Delete" + System.lineSeparator() +
                "0" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase4() {
        final String testString = "2" + System.lineSeparator() +
                "0 1" + System.lineSeparator() +
                "2" + System.lineSeparator() +
                "Delete" + System.lineSeparator() +
                "1" + System.lineSeparator() +
                "Delete" + System.lineSeparator() +
                "0" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase5() {
        String input = "";
        String output = "";
        for (int i = 0; i < 4000; i++) {
            input += i;
            if(i != 3999) {
                input += " ";
            }
        }
        for (int i = 1; i < 4000; i++) {
            output += i;
            if(i != 3999) {
                output += " ";
            }
        }
        final String testString = "4000" + System.lineSeparator() +
                input + System.lineSeparator() +
                "1" + System.lineSeparator() +
                "Delete" + System.lineSeparator() +
                "0" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals(output + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase6() {
        String input = "";
        Integer value = 0;
        for (int i = 0; i < 4000; i++) {
            value += 10000;
            input += value;
            if(i != 3999) {
                input += " ";
            }
        }
        final String testString = "4000" + System.lineSeparator() +
                input + System.lineSeparator() +
                "0" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals(input + System.lineSeparator()
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
