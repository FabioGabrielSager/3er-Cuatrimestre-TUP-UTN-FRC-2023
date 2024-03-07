package ar.edu.utn.frc.tup.lciii;

import java.math.BigDecimal;
import java.math.RoundingMode;

public class Rectangle extends Figure {
    private BigDecimal height, base;

    @Override
    public BigDecimal getPerimeter() {
        return base.multiply(new BigDecimal(2)).add(height.multiply(new BigDecimal(2))).setScale(2, RoundingMode.HALF_UP);
    }

    @Override
    public BigDecimal getArea() {
        return base.multiply(height).setScale(2, RoundingMode.HALF_UP);
    }

    public BigDecimal getHeight() {
        return height;
    }

    public void setHeight(BigDecimal height) {
        this.height = height;
    }

    public BigDecimal getBase() {
        return base;
    }

    public void setBase(BigDecimal base) {
        this.base = base;
    }

    public Rectangle(BigDecimal height, BigDecimal base) {
        this.height = height;
        this.base = base;
    }
}
