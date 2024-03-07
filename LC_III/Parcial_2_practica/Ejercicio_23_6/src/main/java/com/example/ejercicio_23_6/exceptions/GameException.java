package com.example.ejercicio_23_6.exceptions;

// Las runtimes exception son no cheaqueadas y las Exception si lo son, es decir, las Exception deben ser si o si
// manejadas con try...catch o deben agregarse a la firma del método (el método va indicar que puede tirar esa exepción
// en su cabecera).

public class GameException extends RuntimeException{
    public GameException(String message){
        super(message);
    }
}
