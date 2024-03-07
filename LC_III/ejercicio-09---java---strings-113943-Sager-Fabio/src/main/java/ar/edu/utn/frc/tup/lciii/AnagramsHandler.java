package ar.edu.utn.frc.tup.lciii;

public class AnagramsHandler {
    static Boolean isAnagram(String a, String b) {
        // Complete the function
        // IMPORTANT!: Change the return statement in order to return your result.
        Boolean result = true;
        if (a.length() == b.length()){
            int i = 0;
            while(result && i < a.length()){
                char caracterActual = a.toLowerCase().charAt(i);
                if(a.indexOf(caracterActual) != i){
                    int coincidenciasEna = 0;
                    int coincidenciasEnb = 0;
                    for(int j=0;j<a.length();j++) {
                        if (caracterActual == a.toLowerCase().charAt(j))
                            coincidenciasEna++;
                        if (caracterActual == b.toLowerCase().charAt(j))
                            coincidenciasEnb++;
                    }
                    if(coincidenciasEna != coincidenciasEnb)
                        result = false;
                }
                i++;
            }
        }
        else
            result = false;

        return result;
    }
}
