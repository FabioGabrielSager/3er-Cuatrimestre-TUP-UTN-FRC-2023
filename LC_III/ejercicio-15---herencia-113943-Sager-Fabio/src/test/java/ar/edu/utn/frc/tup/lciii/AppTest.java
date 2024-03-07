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
        App.main(new String[0]);
        assertEquals("I'm a Square" + System.lineSeparator() +
                        "\tMy area is: 100.00" + System.lineSeparator() +
                        "\tMy perimeter is: 40.00" + System.lineSeparator() +
                        "I'm a Rectangle" + System.lineSeparator() +
                        "\tMy area is: 200.00" + System.lineSeparator() +
                        "\tMy perimeter is: 60.00" + System.lineSeparator() +
                        "I'm a Circle" + System.lineSeparator() +
                        "\tMy area is: 314.16" + System.lineSeparator() +
                        "\tMy perimeter is: 62.83" + System.lineSeparator() +
                        "The grater figure is : Circle" + System.lineSeparator()
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
