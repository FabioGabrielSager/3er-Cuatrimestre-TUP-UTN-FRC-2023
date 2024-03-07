package ar.edu.utn.frc.tup.lciii;

public class SubStringHandler {

    public static String getSmallestAndLargest(String s, int k) {
        String smallest = "";
        String largest = "";

        for(int i=0; i<=s.length()-k; i++){
            String substringActual= s.substring(i,i+k);

            if(i==0)
                smallest = largest = substringActual;

            else{
                if(smallest.compareTo(substringActual) > 0)
                    smallest = substringActual;
                if(largest.compareTo(substringActual) < 0)
                    largest = substringActual;
            }
        }
        return smallest + "\n" + largest;
    }
}
