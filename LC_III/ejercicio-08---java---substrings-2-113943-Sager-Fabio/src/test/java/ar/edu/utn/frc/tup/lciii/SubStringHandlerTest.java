package ar.edu.utn.frc.tup.lciii;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class SubStringHandlerTest {


    @Test
    public void testCase1() {
        final String testString = "welcometojava";
        final int testLLength = 3;
        final String expected = "ava\nwel";
        String result = SubStringHandler.getSmallestAndLargest(testString, testLLength);
        assertEquals(expected, result);
    }

    @Test
    public void testCase2() {
        final String testString = "WelcomeToJava";
        final int testLLength = 3;
        final String expected = "Jav\nome";
        String result = SubStringHandler.getSmallestAndLargest(testString, testLLength);
        assertEquals(expected, result);
    }

    @Test
    public void testCase3() {
        final String testString = "UniversidadTecnologicaNacional";
        final int testLLength = 5;
        final String expected = "Nacio\nversi";
        String result = SubStringHandler.getSmallestAndLargest(testString, testLLength);
        assertEquals(expected, result);
    }

    @Test
    public void testCase4() {
        final String testString = "TecnicaturaUniversitariaEnProgramacion";
        final int testLLength = 5;
        final String expected = "EnPro\nversi";
        String result = SubStringHandler.getSmallestAndLargest(testString, testLLength);
        assertEquals(expected, result);
    }

    @Test
    public void testCase5() {
        final String testString = "ilovejava";
        final int testLLength = 2;
        final String expected = "av\nve";
        String result = SubStringHandler.getSmallestAndLargest(testString, testLLength);
        assertEquals(expected, result);
    }

    @Test
    public void testCase6() {
        final String testString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        final int testLLength = 25;
        final String expected = "ABCDEFGHIJKLMNOPQRSTUVWXY\nzABCDEFGHIJKLMNOPQRSTUVWX";
        String result = SubStringHandler.getSmallestAndLargest(testString, testLLength);
        assertEquals(expected, result);
    }

    @Test
    public void testCase7() {
        final String testString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        final int testLLength = 52;
        final String expected = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz\nABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        String result = SubStringHandler.getSmallestAndLargest(testString, testLLength);
        assertEquals(expected, result);
    }

    @Test
    public void testCase8() {
        final String testString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        final int testLLength = 1;
        final String expected = "A\nz";
        String result = SubStringHandler.getSmallestAndLargest(testString, testLLength);
        assertEquals(expected, result);
    }

    @Test
    public void testCase9() {
        final String testString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        final int testLLength = 26;
        final String expected = "ABCDEFGHIJKLMNOPQRSTUVWXYZ\nzABCDEFGHIJKLMNOPQRSTUVWXY";
        String result = SubStringHandler.getSmallestAndLargest(testString, testLLength);
        assertEquals(expected, result);
    }

    @Test
    public void testCase10() {
        final String testString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        final int testLLength = 30;
        final String expected = "abcdefghijklmnopqrstuvwxyzABCD\nwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        String result = SubStringHandler.getSmallestAndLargest(testString, testLLength);
        assertEquals(expected, result);
    }
}
