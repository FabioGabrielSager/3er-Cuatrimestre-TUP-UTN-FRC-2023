package ar.edu.utn.frc.tup.lciii;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
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
    public void testCase1() {
        final String testString = "2" + System.lineSeparator() +
                "0 2 10" + System.lineSeparator() +
                "5 3 5" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("2 6 14 30 62 126 254 510 1022 2046" + System.lineSeparator() +
                "8 14 26 50 98" + System.lineSeparator(), getOutput());
    }

    @Test
    public void testCase2() {
        final String testString = "0" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("", getOutput());
    }

    @Test
    public void testCase3() {
        final String testString = "2" + System.lineSeparator() +
                "1 2 3" + System.lineSeparator() +
                "5 2 5" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("3 7 15" + System.lineSeparator() +
                "7 11 19 35 67" + System.lineSeparator(), getOutput());
    }

    @Test
    public void testCase4() {
        final String testString = "10" + System.lineSeparator() +
                "0 5 9" + System.lineSeparator() +
                "1 6 10" + System.lineSeparator() +
                "2 7 11" + System.lineSeparator() +
                "3 8 12" + System.lineSeparator() +
                "4 9 13" + System.lineSeparator() +
                "5 10 14" + System.lineSeparator() +
                "6 11 15" + System.lineSeparator() +
                "20 30 15" + System.lineSeparator() +
                "0 50 15" + System.lineSeparator() +
                "50 0 1" + System.lineSeparator();
        provideInput(testString);
        App.main(new String[0]);
        assertEquals("5 15 35 75 155 315 635 1275 2555" + System.lineSeparator() +
                "7 19 43 91 187 379 763 1531 3067 6139" + System.lineSeparator() +
                "9 23 51 107 219 443 891 1787 3579 7163 14331" + System.lineSeparator() +
                "11 27 59 123 251 507 1019 2043 4091 8187 16379 32763" + System.lineSeparator() +
                "13 31 67 139 283 571 1147 2299 4603 9211 18427 36859 73723" + System.lineSeparator() +
                "15 35 75 155 315 635 1275 2555 5115 10235 20475 40955 81915 163835" + System.lineSeparator() +
                "17 39 83 171 347 699 1403 2811 5627 11259 22523 45051 90107 180219 360443" + System.lineSeparator() +
                "50 110 230 470 950 1910 3830 7670 15350 30710 61430 122870 245750 491510 983030" + System.lineSeparator() +
                "50 150 350 750 1550 3150 6350 12750 25550 51150 102350 204750 409550 819150 1638350" + System.lineSeparator() +
                "50" + System.lineSeparator(), getOutput());
    }

    private void provideInput(String data) {
        testIn = new ByteArrayInputStream(data.getBytes());
        System.setIn(testIn);
    }

    private String getOutput() {
        return testOut.toString();
    }
}
