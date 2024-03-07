package com.example.ejercicio_23_6.Services;

import com.example.ejercicio_23_6.Entities.Game;
import org.springframework.stereotype.Service;

@Service
public interface GameService {
    Game createGame(String username);
    Game guessLetter(Long id, String letter);
}
