package com.example.ejercicio_23_6.Repositories;

import com.example.ejercicio_23_6.Entities.Game;
import org.springframework.data.jpa.repository.JpaRepository;

public interface GameRepository extends JpaRepository<Game,Long> {
}
