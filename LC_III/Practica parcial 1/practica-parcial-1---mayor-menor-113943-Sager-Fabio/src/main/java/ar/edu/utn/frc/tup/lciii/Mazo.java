package ar.edu.utn.frc.tup.lciii;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Mazo {

    private List<Carta> cartas;

    public List<Carta> getCartas() {
        return cartas;
    }

    public Mazo() {
        inicializarMazo();
    }

    /**
     * Este metodo mescla las cartas del mazo para jugar
     *
     * Ver Clase Collections
     */
    public void mesclarCartas() {
        Collections.shuffle(cartas);
    }

    /**
     * Este metodo crea cada carta y la agrega al mazo, como resultado retorna un mazo de 40 cartas españolas
     * @return
     */
    private List<Carta> inicializarMazo() {
        cartas = new ArrayList<>();
        for (int i = 1; i <= 10; i++) {
            cartas.add(new Carta(Palo.BASTO, i));
            cartas.add(new Carta(Palo.ORO, i));
            cartas.add(new Carta(Palo.COPA, i));
            cartas.add(new Carta(Palo.ESPADA, i));
        }
        return cartas;
    }
}
