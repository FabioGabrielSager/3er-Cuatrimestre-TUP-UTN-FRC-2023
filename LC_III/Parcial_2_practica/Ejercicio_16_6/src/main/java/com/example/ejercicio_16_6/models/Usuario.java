package com.example.ejercicio_16_6.models;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
public class Usuario {
    private Long id;
    private String nombre;
    private boolean is_npc;
}
