package ar.edu.utn.frc.tup.lciii;

public class Carta {
    private Palo palo;
    private int valor;

    public void mostrarCarta(){
        System.out.println("Palo: " + palo + " Valor: " + valor);
    }

    public Carta(Palo palo, int valor) {
        this.palo = palo;
        this.valor = valor;
    }

    public Palo getPalo() {
        return palo;
    }

    public void setPalo(Palo palo) {
        this.palo = palo;
    }

    public int getValor() {
        return valor;
    }

    public void setValor(int valor) {
        this.valor = valor;
    }
}
