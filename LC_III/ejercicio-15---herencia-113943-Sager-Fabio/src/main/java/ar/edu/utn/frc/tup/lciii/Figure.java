package ar.edu.utn.frc.tup.lciii;

import java.math.BigDecimal;
import java.math.BigInteger;

public abstract class Figure {
    public abstract BigDecimal getPerimeter();

    public abstract BigDecimal getArea();

    public boolean isGreater(Figure figure){
        return getArea().compareTo(figure.getArea()) > 0;
    }
}
