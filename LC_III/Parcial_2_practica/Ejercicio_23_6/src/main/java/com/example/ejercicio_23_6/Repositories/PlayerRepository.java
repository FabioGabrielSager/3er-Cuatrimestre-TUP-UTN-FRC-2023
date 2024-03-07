package com.example.ejercicio_23_6.Repositories;

import com.example.ejercicio_23_6.Entities.Player;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface PlayerRepository extends JpaRepository<Player, Long> {
    Optional<Player> findByUsername(String username);
}
