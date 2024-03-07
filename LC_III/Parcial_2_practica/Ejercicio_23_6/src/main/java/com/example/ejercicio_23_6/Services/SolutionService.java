package com.example.ejercicio_23_6.Services;

import com.example.ejercicio_23_6.Entities.Solution;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface SolutionService {
    List<Solution> createSolution(List<String> solutions);
}
