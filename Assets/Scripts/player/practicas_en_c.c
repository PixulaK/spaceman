#include <stdio.h>

int main(){

    int n;
    printf("Introduzca el numero a eleccion: \n");
    scanf("%d\n", &n);

    if (n > 99)
    {
        if (n > 99)
            printf("El numero [%d] supera el limite inferior.\n", n);
        else(n > 199)
            printf("El numero [%d] supera el limite superior\n", n);
    }
    else
        printf("El numero [%d] no supera el limite.", n);


}