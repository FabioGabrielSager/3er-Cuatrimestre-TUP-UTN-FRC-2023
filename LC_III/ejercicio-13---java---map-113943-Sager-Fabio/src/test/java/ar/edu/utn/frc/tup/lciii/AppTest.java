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
        final String testString = "3" + System.lineSeparator() +
                "uncle sam" + System.lineSeparator() +
                "99912222" + System.lineSeparator() +
                "tom" + System.lineSeparator() +
                "11122222" + System.lineSeparator() +
                "harry" + System.lineSeparator() +
                "12299933" + System.lineSeparator() +
                "uncle sam" + System.lineSeparator() +
                "uncle tom" + System.lineSeparator() +
                "harry" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("uncle sam=99912222" + System.lineSeparator() +
                        "Not found" + System.lineSeparator() +
                        "harry=12299933" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase2() {
        final String testString = "5" + System.lineSeparator() +
                "uncle sam" + System.lineSeparator() +
                "99912222" + System.lineSeparator() +
                "tom" + System.lineSeparator() +
                "11122222" + System.lineSeparator() +
                "harry" + System.lineSeparator() +
                "12299933" + System.lineSeparator() +
                "hary" + System.lineSeparator() +
                "12299933" + System.lineSeparator() +
                "harri" + System.lineSeparator() +
                "12299933" + System.lineSeparator() +
                "uncle sam" + System.lineSeparator() +
                "uncle tom" + System.lineSeparator() +
                "tom" + System.lineSeparator() +
                "hari" + System.lineSeparator() +
                "harry" + System.lineSeparator() +
                "Jerry" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("uncle sam=99912222" + System.lineSeparator() +
                        "Not found" + System.lineSeparator() +
                        "tom=11122222" + System.lineSeparator() +
                        "Not found" + System.lineSeparator() +
                        "harry=12299933" + System.lineSeparator() +
                        "Not found" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase3() {
        final String testString = "0" + System.lineSeparator() +
                "uncle sam" + System.lineSeparator() +
                "uncle tom" + System.lineSeparator() +
                "tom" + System.lineSeparator() +
                "hari" + System.lineSeparator() +
                "harry" + System.lineSeparator() +
                "Jerry" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("Not found" + System.lineSeparator() +
                        "Not found" + System.lineSeparator() +
                        "Not found" + System.lineSeparator() +
                        "Not found" + System.lineSeparator() +
                        "Not found" + System.lineSeparator() +
                        "Not found" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase4() {
        final String testString = "5" + System.lineSeparator() +
                "uncle sam" + System.lineSeparator() +
                "99912222" + System.lineSeparator() +
                "tom" + System.lineSeparator() +
                "11122222" + System.lineSeparator() +
                "harry" + System.lineSeparator() +
                "12299933" + System.lineSeparator() +
                "hary" + System.lineSeparator() +
                "12299933" + System.lineSeparator() +
                "harri" + System.lineSeparator() +
                "12299933" + System.lineSeparator() +
                "uncle sam" + System.lineSeparator() +
                "tom" + System.lineSeparator() +
                "harry" + System.lineSeparator() +
                "hary" + System.lineSeparator() +
                "harri" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("uncle sam=99912222" + System.lineSeparator() +
                        "tom=11122222" + System.lineSeparator() +
                        "harry=12299933" + System.lineSeparator() +
                        "hary=12299933" + System.lineSeparator() +
                        "harri=12299933" + System.lineSeparator()
                , getOutput());
    }

    @Test
    public void testCase5() {
        final String testString = "5" + System.lineSeparator() +
                "uncle sam" + System.lineSeparator() +
                "99912222" + System.lineSeparator() +
                "tom" + System.lineSeparator() +
                "11122222" + System.lineSeparator() +
                "harry" + System.lineSeparator() +
                "12299933" + System.lineSeparator() +
                "hary" + System.lineSeparator() +
                "12299933" + System.lineSeparator() +
                "uncle sam" + System.lineSeparator() +
                "12299933" + System.lineSeparator() +
                "uncle sam" + System.lineSeparator() +
                "tom" + System.lineSeparator() +
                "harry" + System.lineSeparator() +
                "hary" + System.lineSeparator() +
                "harri" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("uncle sam=12299933" + System.lineSeparator() +
                        "tom=11122222" + System.lineSeparator() +
                        "harry=12299933" + System.lineSeparator() +
                        "hary=12299933" + System.lineSeparator() +
                        "Not found" + System.lineSeparator()
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
