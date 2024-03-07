package com.example.ejercicio_23_6.Services.Imps;

import com.example.ejercicio_23_6.Entities.Game;
import com.example.ejercicio_23_6.Entities.Player;
import com.example.ejercicio_23_6.Repositories.GameRepository;
import com.example.ejercicio_23_6.Repositories.PlayerRepository;
import com.example.ejercicio_23_6.Repositories.SolutionRepository;
import com.example.ejercicio_23_6.Services.GameService;
import com.example.ejercicio_23_6.exceptions.GameException;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.Random;

import com.example.ejercicio_23_6.Entities.Solution;

@Service
@RequiredArgsConstructor
public class GameServiceImp implements GameService {

    private final GameRepository gameRepository;
    private final PlayerRepository playerRepository;
    private final SolutionRepository solutionRepository;

    @Override
    public Game createGame(String username) {
        Optional<Player> playerOptional = playerRepository.findByUsername(username);
        Player player;
        if(playerOptional.isEmpty()){
            player = playerRepository.save(Player.builder().username(username).build());
        }
        else {
            player = playerOptional.get();
        }

        List<Solution> avaiblableSolution = solutionRepository.findAll();
        Random randomGen = new Random();
        Integer ix = randomGen.nextInt(avaiblableSolution.size());
        Solution pickedSolution = avaiblableSolution.get(ix);

        Game newGame = Game.builder().player(player).solution(pickedSolution).score(0).lettersGuessed(new ArrayList<>())
                .finished(false).build();
        Game savedGame = gameRepository.save(newGame);
        savedGame.getSolution().getWord().replaceAll(".", "_");

        return savedGame;
    }

    @Override
    public Game guessLetter(Long id, String letter) {

        Optional<Game> gameOptional = gameRepository.findById(id);

        gameOptional.orElseThrow(() -> new GameException("Juego no encontrado, pone bien la ID pibe"));

        Game game = gameOptional.get();

        if(game.getFailedAttempts() > 6) throw new GameException("Este juego ya termino");
        if(letter.length() != 1) throw new GameException("Solo debe ingresar una letra");
        if(game.getLettersGuessed().contains(letter)) throw new GameException("Esa letra ya fue seleccionada");
        if(game.getSolution().getWord().contains(letter)) {
            game.setScore(game.getScore() + 2);
        } else {
            if(game.getScore() != 0) game.setScore(game.getScore() - 1);
            if(game.getFailedAttempts() == 6) game.setFinished(true);
        }

        game.getLettersGuessed().add(letter);
        String word = game.getSolution().getWord();

        StringBuilder stringBuilder = new StringBuilder();

        for(String l : word.split("")){
            if(game.getLettersGuessed().contains(l)){
                stringBuilder.append(l);
            }
            else {
                stringBuilder.append("_");
            }
        }

        if(!stringBuilder.toString().contains("_")) {
            game.setScore(game.getScore() + 10);
            game.setFinished(true);
        }

        game.getSolution().setWord(stringBuilder.toString());

        return gameRepository.save(game);
    }
}
