package ar.edu.utn.frc.tup.lciii;

public class Juego {
    private Mazo mazo;
    private int cartasRestantes;
    private int cartasAdivinadas;
    private int cartaActual;

    public int getCartaActual() {
        return cartaActual;
    }

    public void setCartaActual(int cartaActual) {
        this.cartaActual = cartaActual;
    }

    public Juego() {
        this.mazo = new Mazo();
        mazo.mesclarCartas();
        this.cartasRestantes = 0;
        this.cartasAdivinadas = 0;
        this.cartaActual = 0;
    }

    public boolean verificarSiHayFallo(String adivinanza){
        if(adivinanza.equalsIgnoreCase("ma"))
            return mazo.getCartas().get(cartaActual).getValor() < mazo.getCartas().get(cartaActual + 1).getValor();
        if(adivinanza.equalsIgnoreCase("me"))
            return mazo.getCartas().get(cartaActual).getValor() > mazo.getCartas().get(cartaActual + 1).getValor();
        return false;
    }
    public boolean verificarSiGano(){
        return cartasRestantes == 0;
    }
}
