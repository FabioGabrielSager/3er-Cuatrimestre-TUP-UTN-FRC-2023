package ar.edu.utn.frc.tup.lciii;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class AnagramsHandlerTest {


    @Test
    public void testCase1() {
        final String a = "anagram";
        final String b = "margana";
        assertTrue(AnagramsHandler.isAnagram(a, b));
    }

    @Test
    public void testCase2() {
        final String a = "anagramm";
        final String b = "marganaa";
        assertFalse(AnagramsHandler.isAnagram(a, b));
    }

    @Test
    public void testCase3() {
        final String a = "Hello";
        final String b = "hello";
        assertTrue(AnagramsHandler.isAnagram(a, b));
    }
}
