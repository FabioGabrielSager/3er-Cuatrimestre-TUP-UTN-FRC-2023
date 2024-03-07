package com.example.ejercicio_23_6.Services.Imps;

import com.example.ejercicio_23_6.Entities.Solution;
import com.example.ejercicio_23_6.Repositories.SolutionRepository;
import com.example.ejercicio_23_6.Services.SolutionService;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class SolutionServiceImp implements SolutionService {
    private final SolutionRepository solutionRepository;

    @Override
    public List<Solution> createSolution(List<String> solutions) {

       List<Solution> domainSolutionsList = solutions.stream().map((word) -> Solution.builder().word(word).build())
                .collect(Collectors.toList());

       return solutionRepository.saveAll(domainSolutionsList);
    }
}
