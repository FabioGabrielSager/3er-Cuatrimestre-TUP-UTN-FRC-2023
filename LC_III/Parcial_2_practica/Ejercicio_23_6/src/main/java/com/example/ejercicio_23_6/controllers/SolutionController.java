package com.example.ejercicio_23_6.controllers;

import com.example.ejercicio_23_6.Entities.Solution;
import com.example.ejercicio_23_6.Services.SolutionService;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
// Esta notación te crea un constructor solo con los campos requeridos
@RequiredArgsConstructor
public class SolutionController {

    private final SolutionService solutionService;

    @PostMapping("/hangman/solutions")
    List<Solution> createSolutions(@RequestBody List<String> solutions){

    }
}
