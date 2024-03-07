package ar.edu.utn.frc.tup.lciii;

import java.util.ArrayList;
import java.util.List;

public class Juego {

    private static PalabrasService palabrasService = new PalabrasService();

    private String palabraEnJuego;
    private String palabraModoOculto;
    private List<Character> letrasElegidas;
    private Integer vidasJugador;
    private Integer puntosJuego;
    private Integer coincidencias;

    public String getPalabraEnJuego() {
        return palabraEnJuego;
    }

    public void setPalabraEnJuego(String palabraEnJuego) {
        this.palabraEnJuego = palabraEnJuego;
    }

    public void setPalabraModoOculto(String palabraModoOculto) {
        this.palabraModoOculto = palabraModoOculto;
    }

    public List<Character> getLetrasElegidas() {
        return letrasElegidas;
    }

    public void setLetrasElegidas(List<Character> letrasElegidas) {
        this.letrasElegidas = letrasElegidas;
    }

    public Integer getVidasJugador() {
        return vidasJugador;
    }

    public void setVidasJugador(Integer vidasJugador) {
        this.vidasJugador = vidasJugador;
    }

    public Integer getPuntosJuego() {
        return puntosJuego;
    }

    public void setPuntosJuego(Integer puntosJuego) {
        this.puntosJuego = puntosJuego;
    }

    public Juego() {
        this.palabraEnJuego = palabrasService.getPalabra();
        this.palabraModoOculto = this.getPalabraModoOculto();
        this.letrasElegidas = new ArrayList<>();
        this.vidasJugador = 6;
        this.puntosJuego = 0;
        this.coincidencias = 0;
    }

    public void addLetra(Character letra) {
        letrasElegidas.add(letra);
        StringBuilder palabraOcultaConCoincidencias = new StringBuilder(palabraModoOculto);
        boolean huboCoincidencia = false;
        for (int i = 0; i < palabraEnJuego.length(); i++) {
            if(palabraEnJuego.charAt(i) == letra) {
                palabraOcultaConCoincidencias.setCharAt(i, palabraEnJuego.charAt(i));
                coincidencias += 1;
                puntosJuego += 2;
                huboCoincidencia = true;
            }
        }
        palabraModoOculto = String.valueOf(palabraOcultaConCoincidencias);
        if(!huboCoincidencia)
            vidasJugador -= 1;
    }

    /**
     * Este metodo debe verificar si el juego termnó porque ganó el jugador o porque se acabaron las vidas.
     * Cuando se lo llama y el juego no terminó, debe descontar las vidas y calcular el puntaje de este juego.
     *
     * @return si el juego ha terminado o no
     */
    public Boolean calcularEstadoDelJuego() {
        boolean termino = false;
        if(coincidencias == palabraEnJuego.length()){
            puntosJuego += 10;
            termino = true;
        } else if (vidasJugador == 0) {
            termino = true;
        }
        return termino;
    }

    /**
     * Este metodo genera la palabra en modo oculto, es decir, muestra las
     * letras encontradas, sino, muestra guones bajos
     *
     * @return La palabra en juego en modo oculto
     */
    public String getPalabraModoOculto() {
        return "_".repeat(palabraEnJuego.length());
    }

    /**
     * Este metodo dibuja el juego por cada iteracion, es decir, pinta la palabra oculta
     * con sus espacios en blanco (guiones bajos) y sus espacios ocupados por las letras ya elegidas;
     * y el resto de la informacion referente al juego, cantidad de vidas que restan por ejemplo.
     *
     */
    public void dibujar() {
        System.out.println("Vidas restantes: " + vidasJugador);
        System.out.println("Puntaje: " + puntosJuego);
        System.out.println("Letras elegidas: " + letrasElegidas);
        System.out.println(palabraModoOculto);
    }
}
