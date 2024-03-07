package com.example.ejercicio_23_6.controllers;

import com.example.ejercicio_23_6.Entities.Player;
import com.example.ejercicio_23_6.Repositories.PlayerRepository;
import com.example.ejercicio_23_6.exceptions.GameException;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequiredArgsConstructor
public class PlayerController {
    private final PlayerRepository playerRepository;

    @GetMapping("/hangman/player/{username}")
    Player getPlayer(@PathVariable String username){
        return playerRepository.findByUsername(username).
                orElseThrow( () -> new GameException("No se encontro el player"));
    }
}
