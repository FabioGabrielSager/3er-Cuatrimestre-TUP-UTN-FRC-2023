package com.example.ejercicio_23_6.controllers;

import com.example.ejercicio_23_6.Entities.Game;
import com.example.ejercicio_23_6.Services.GameService;
import com.example.ejercicio_23_6.dtos.GameDTO;
import jakarta.websocket.server.PathParam;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.*;

@RestController
@RequiredArgsConstructor
public class GameController {

    private final GameService gameService;

    @PostMapping("hangman/game")
    Game createGame(@RequestBody GameDTO gameDTO){
        return gameService.createGame(gameDTO.getPlayerUsername());
    }

    @PostMapping("hangman/game/{id}")
    // Ver notación @valid
    Game guessLetter(@PathVariable Long id, @RequestParam String letter){
        return gameService.guessLetter(id, letter);
    }
}
