package ar.edu.utn.frc.tup.lciii;

import java.math.BigDecimal;
import java.math.RoundingMode;

public class Circle extends Figure{
    private BigDecimal radius;

    @Override
    public BigDecimal getPerimeter() {
        return radius.multiply(new BigDecimal(2)).multiply(new BigDecimal(Math.PI)).setScale(2, RoundingMode.HALF_UP);
    }

    @Override
    public BigDecimal getArea() {
        return radius.pow(2).multiply(new BigDecimal(Math.PI)).setScale(2, RoundingMode.HALF_UP);
    }

    public BigDecimal getRadius() {
        return radius;
    }

    public void setRadius(BigDecimal radius) {
        this.radius = radius;
    }

    public Circle(BigDecimal radius) {
        this.radius = radius;
    }
}
