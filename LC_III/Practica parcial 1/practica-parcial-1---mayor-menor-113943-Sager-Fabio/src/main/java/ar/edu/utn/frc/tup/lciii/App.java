package ar.edu.utn.frc.tup.lciii;

/**
 * Hello to Practica Parcial 1 - MAYOR/MENOR
 *
 */
public class App 
{
    private static Solitario solitario = new Solitario();

    /**
     * This is the main program
     * 
     */
    public static void main( String[] args ) {
        System.out.println("Hello, Practica Parcial 1 - MAYOR/MENOR.");
        // Mensaje de Bienvenida
        solitario.bienvenida();
        // Inicio un bucle para empezar a Jugar
        do {
            // Creo el Mazo y lo mesclo
            Mazo mazo = new Mazo();
            mazo.mesclarCartas();
            int cartasRestantes = mazo.getCartas().size();
            int cartasAdivinadas = 0;
            int indiceCartaActual = 0;
            Carta cartaActual = mazo.getCartas().get(indiceCartaActual);
            boolean termino = false;

            //Inicio otro bucle para empezar un juego de solitario
            while(!termino){
                // Muestro la primera carta del mazo
                // Pregunto por la decicion del jugador si la siguiente es mayor o menor
                // Recojo la respuesta
                String adivinanza = solitario.pedirAdivinanza(cartaActual);
                // Muestro la siguiente carta
                mazo.getCartas().get(indiceCartaActual + 1).mostrarCarta();
                // Valido la respuesta
                if(adivinanza.equalsIgnoreCase("ma") &&
                        cartaActual.getValor() <= mazo.getCartas().get(indiceCartaActual + 1).getValor() ||
                        adivinanza.equalsIgnoreCase("me") &&
                                cartaActual.getValor() >= mazo.getCartas().get(indiceCartaActual + 1).getValor())
                        if(cartasRestantes-1 == 0)
                            termino = true;
                        else {
                            System.out.println("Correcto!");
                            indiceCartaActual++;
                            cartasAdivinadas++;
                            cartasRestantes--;
                            System.out.println("Cartas adivinadas: " + cartasAdivinadas);
                            System.out.println("Cartas restantes: " + cartasRestantes);
                        }
                else {
                    termino = true;
                }
                cartaActual = mazo.getCartas().get(indiceCartaActual);
            }

            if(cartasRestantes == 0){
                System.out.println("Ganaste la partida");
                solitario.getJugador().setCantidadPartidasGanadas(
                        solitario.getJugador().getCantidadPartidasGanadas()+1);
            }
            else {
                System.out.println("Perdiste la partida");
                solitario.getJugador().setCantidadPartidasPerdidas(
                        solitario.getJugador().getCantidadPartidasPerdidas()+1);
            }
            solitario.mostrarEstadisticasJugador();
        }
        while (solitario.continuarJugando());
                // Pregunto para volver a jugar
                // Si quiere volver a jugar, retomo el bucle principal

    }
}
