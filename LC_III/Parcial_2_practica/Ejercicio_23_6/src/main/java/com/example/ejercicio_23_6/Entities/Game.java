package com.example.ejercicio_23_6.Entities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import jakarta.persistence.criteria.Fetch;
import lombok.*;

import java.util.List;

@Entity
@Builder
@Data
@AllArgsConstructor
@NoArgsConstructor
@Getter @Setter
public class Game {
    @Id
    @GeneratedValue( strategy = GenerationType.IDENTITY)
    private Long id;

    private Integer score;

    private List<String> lettersGuessed;

    private boolean finished;

    @ManyToOne(fetch = FetchType.LAZY)
    private Solution solution;

    @JsonIgnore
    @ManyToOne(fetch = FetchType.LAZY)
    private Player player;

    @Transient // Esta notación le indica a hibernate que ignore estos campos
    private Integer failedAttempts;
    @Transient
    private Integer succesfulAttempts;

    public Integer getFailedAttempts(){
        Integer attemps = 0;
        for(String letter : lettersGuessed){
            if (!solution.getWord().contains(letter)) {
                attemps += 1;
            }
        }
        return attemps;
    }

    public Integer getSuccefulyAttempts(){
        Integer attemps = 0;
        for(String letter : lettersGuessed){
            if (solution.getWord().contains(letter)) {
                attemps += 1;
            }
        }
        return attemps;
    }
}
