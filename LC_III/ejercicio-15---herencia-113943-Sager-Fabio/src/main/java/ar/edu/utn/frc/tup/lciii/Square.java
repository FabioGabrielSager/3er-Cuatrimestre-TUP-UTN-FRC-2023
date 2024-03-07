package ar.edu.utn.frc.tup.lciii;

import java.math.BigDecimal;
import java.math.RoundingMode;

public class Square extends Figure{
    private BigDecimal size;
    @Override
    public BigDecimal getPerimeter() {
        return size.multiply(new BigDecimal(4)).setScale(2, RoundingMode.HALF_UP);
    }

    @Override
    public BigDecimal getArea() {
        return size.pow(2).setScale(2, RoundingMode.HALF_UP);
    }

    public BigDecimal getSize() {
        return size;
    }

    public void setSize(BigDecimal size) {
        this.size = size;
    }

    public Square(BigDecimal sidesSize) {
        this.size = sidesSize;
    }
}
