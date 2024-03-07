package ar.edu.utn.frc.tup.lciii;

public class Jugador {
    private String nombre;
    private int cantidadPartidasGanadas=0;
    private int cantidadPartidasPerdidas=0;

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getCantidadPartidasGanadas() {
        return cantidadPartidasGanadas;
    }

    public void setCantidadPartidasGanadas(int cantidadPartidasGanadas) {
        this.cantidadPartidasGanadas = cantidadPartidasGanadas;
    }

    public int getCantidadPartidasPerdidas() {
        return cantidadPartidasPerdidas;
    }

    public void setCantidadPartidasPerdidas(int cantidadPartidasPerdidas) {
        this.cantidadPartidasPerdidas = cantidadPartidasPerdidas;
    }
}
