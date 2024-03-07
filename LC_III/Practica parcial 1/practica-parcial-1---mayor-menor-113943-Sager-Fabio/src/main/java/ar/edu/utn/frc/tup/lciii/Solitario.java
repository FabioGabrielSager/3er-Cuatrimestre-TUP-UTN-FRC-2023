package ar.edu.utn.frc.tup.lciii;

import java.util.Scanner;

public class Solitario {
    private Jugador jugador;
    private Scanner scanner;

    public Solitario() {
        this.jugador = new Jugador();
        this.scanner = new Scanner(System.in);
    }

    public Jugador getJugador() {
        return jugador;
    }

    public void setJugador(Jugador jugador) {
        this.jugador = jugador;
    }

    public void bienvenida(){
        System.out.println("Bienvenido al Solitario!");
        System.out.print("Por favor, ingrese su nombre de usuario: ");
        jugador.setNombre(scanner.nextLine());
    }

    public String pedirAdivinanza(Carta cartaActual){
        String adivinanza;
        System.out.print("La carta actual es: ");
        cartaActual.mostrarCarta();
        System.out.println("Ingrese si cree que la siguiente carta sera mayor o menor (ma o me): ");
        do {
            adivinanza = scanner.next();
            if(!(adivinanza.equalsIgnoreCase("ma") || adivinanza.equalsIgnoreCase("me")))
                System.out.println("Error, ingrese 'ma' para mayor o 'me' para menor");
        }while (!(adivinanza.equalsIgnoreCase("ma") || adivinanza.equalsIgnoreCase("me")));
        return adivinanza;
    }

    public boolean continuarJugando(){
        String eleccion;
        System.out.println("Quiere seguir jugando? (si o no)");
        do {1
            eleccion = scanner.nextLine();
            if(!(eleccion.equalsIgnoreCase("si") || eleccion.equalsIgnoreCase("no")))
                System.out.println("Error, ingrese si o no");
        }while(!(eleccion.equalsIgnoreCase("si") || eleccion.equalsIgnoreCase("no")));
        return eleccion.equalsIgnoreCase("si");
    }

    public void mostrarEstadisticasJugador(){
        System.out.println("Partidas ganadas: " + jugador.getCantidadPartidasGanadas());
        System.out.println("Partidas perdida: " + jugador.getCantidadPartidasGanadas());
    }
}
