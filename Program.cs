using System;
using System.IO;

namespace arbolito
{
    class Program
    {
        const int baseMax = 41;
        public static string repetir(string a, int n){
            string respuesta = "";
            for (int i = 0; i < n; i++){
                respuesta += a;
            }
            return respuesta;
        }

         public static string repetirEsp(string a, int n){
            string respuesta = "";
            for (int i = 0; i < n; i++){
                respuesta += a + ' ';
            }
            return respuesta;
        }

        public static char[,] crearArregloChar(int dimen, char ch) {
            char[,] arreglo = new char[dimen, dimen + 1];
            for (int y = 0; y < dimen +1; y++ ) {
                for (int x = 0; x < dimen; x ++) {
                    arreglo[x,y] = ch;
                }
            }
            return arreglo;
        }

        public static string construirFila(char[,] arreglo, int posY) {
            int longitud = arreglo.GetLength(0);
            string salida = "";
            for (int i = 0; i < longitud; i++){
                salida += arreglo[i,posY];
            }
            return salida;
        }

        public static Boolean validaTamFig(string fig, int tam){
            switch (fig) {
                case "triangulo iso":
                    if (tam > 2 && tam < 42 ) {
                        return true;
                    } else {
                        return false;
                    }  
                case "triangulo":
                    if (tam > 1 && tam < 22 ) {
                        return true;
                    } else {
                        return false;
                    }                      
                case "espiral":
                     if (tam > 4 && tam < 42 ) {
                        return true;
                    } else {
                        return false;
                    }
                default:
                    return false;
            }
        }

        public static int solicitaTamano(string pregunta) {
            string respuesta;
            int salida = 0;
            Console.Write(" " + pregunta + " ");
            respuesta = Console.ReadLine();
            try {
                salida = Int16.Parse(respuesta);
            } catch (FormatException) {
                Console.WriteLine("Lo siento pero el tamaño solo debe de ser un"
                                     + " número entero válido.");
                Console.WriteLine("Presiona cualquier tecla para continuar " 
                                    + "...");
                Console.ReadLine();
                Environment.Exit(0);
            }
            return salida;
        }

        public static Boolean validaChar(string a) {
            if (a == "") {
                Console.Write("\n Lo siento el carácter no debe de ser un "             
                                    + "espacio ni estar vacio. Intenta la " 
                                    + "próxima.");
                return false;
            } else if (a.Length > 1) {
                Console.Write("\n Lo siento solo debe de ser solo un carácter. " 
                                    + "Intenta la próxima.");
                return false;
            } else {
                return true;
            }           
        }

        public static string centradoTrian(string txt, int tamMax) {
            int tamano = txt.Trim().Length;
            int numEsp = (tamMax-tamano)/2;
            string espacioD;
            string espacioI = repetir(" ", numEsp);
            if (tamano%2 == 0) {
                espacioD = repetir(" ", numEsp + 1);
            } else {
                espacioD = espacioI;
            }
            return espacioI + txt.Trim() + espacioD;
        }

        public static void triangulo(string a, int tamano){            
            int baseC = 1;
            string salida = "";
            if (validaChar(a.Trim())) {
                Console.WriteLine("|-------------------------------------------"
                                    + "|");
                Console.WriteLine("|                  TRIANGULO                "
                                    + "|");
                Console.WriteLine("|-------------------------------------------"
                                    + "|");
                Console.WriteLine("|                                           "
                                    + "|");              
                do {
                    salida = repetirEsp(a , baseC).Trim();
                    Console.Write($"| {centradoTrian(salida,baseMax)} |\n");
                    baseC = baseC + 1;            
                } while (tamano >= baseC);
                Console.WriteLine("|                                           "
                                    + "|");
                Console.WriteLine("|-------------------------------------------" 
                                    + "|");
            }
        }
        public static void trianguloIso(string a, int tamano){
            int baseC = 1;
            int espacios = 0;
            string salida = "";
            string espaciosC = "";
            if (validaChar(a.Trim())) {
                Console.WriteLine("|-------------------------------------------"
                                    + "|");
                Console.WriteLine("|                  TRIANGULO                "
                                    + "|");
                Console.WriteLine("|-------------------------------------------"
                                    + "|");
                Console.WriteLine("|                                           "
                                    + "|");
                do {
                    espacios = (baseMax - baseC)/2;
                    espaciosC = repetir(" " , espacios);
                    salida += espaciosC + repetir(a , baseC) + espaciosC;
                    Console.Write($"| {salida} |\n");
                    salida = "";
                    baseC = baseC + 2;            
                } while (tamano >= baseC);
                Console.WriteLine("|                                           "
                                    + "|");
                Console.WriteLine("|-------------------------------------------" 
                                    + "|");
            }
        }

        public static void espiral(string a, int tamano){
            int numEsp = (baseMax-tamano)/2;
            int caracteresFaltantes = caracteresPorDibujar(tamano);
            string espacioD;
            string espacioI = repetir(" ", numEsp);
            if (tamano%2 == 0) {
                espacioD = repetir(" ", numEsp + 1);
            } else {
                espacioD = espacioI;
            }
            char[,] arreglo = crearArregloChar(tamano, ' ');
            int dimensionX = arreglo.GetLength(0);
            int dimensionY = arreglo.GetLength(1);
            int posicionX = 0;
            int posicionY = 0;            
            if (validaChar(a.Trim())) {
                Console.WriteLine("|-------------------------------------------"
                                    + "|");
                Console.WriteLine("|                   ESPIRAL                 "
                                    + "|");
                Console.WriteLine("|-------------------------------------------"
                                    + "|");
                Console.WriteLine("|                                           "
                                    + "|");
                for (int i = 0; i < dimensionX; i++) {                   
                    arreglo.SetValue(Char.Parse(a.Trim()),i,posicionY);
                    posicionX = i;
                }
                for (int i = 1; i < dimensionY; i++) {
                    arreglo.SetValue(Char.Parse(a.Trim()),posicionX,i);
                    posicionY = i;
                }
                dimensionX--;
                dimensionY--;
                int contadores = 1;
                do
                {                                   
                    for (int i = 0; i <= dimensionX-contadores; i++) {
                        posicionX--;
                        caracteresFaltantes--;                                              
                        arreglo.SetValue(Char.Parse(a.Trim()),posicionX,posicionY);                        
                    }           
                    contadores++;                           
                    if (caracteresFaltantes < 1) break;                        
                    for (int i = 0; i < dimensionY-contadores; i++) {
                        posicionY--;
                        caracteresFaltantes--;
                        arreglo.SetValue(Char.Parse(a.Trim()),posicionX,posicionY);                       
                    } 
                    contadores++;             
                    if (caracteresFaltantes < 1) break;                    
                    for (int i = 0; i <= dimensionX-contadores; i++) {
                        posicionX++;
                        caracteresFaltantes--;
                        arreglo.SetValue(Char.Parse(a.Trim()),posicionX,posicionY);                        
                    }   
                    contadores++;                                    
                    if (caracteresFaltantes < 1) break;                        
                    for (int i = 0; i < dimensionY-contadores; i++) {
                        posicionY++;
                        caracteresFaltantes--;
                        arreglo.SetValue(Char.Parse(a.Trim()),posicionX,posicionY);                       
                    } 
                    contadores++;                          
                } while (caracteresFaltantes > 0);
                for (int pY = 0; pY < arreglo.GetLength(1); pY++){
                    Console.WriteLine($"| {espacioI}" + 
                                    $"{construirFila(arreglo, pY)}" + 
                                    $"{espacioD} |"); 
                }
                Console.WriteLine("|                                           "
                                    + "|");
                Console.WriteLine("|-------------------------------------------"
                                    + "|");
            }
        }

         public static void espiralMagico(int tamano){
            int numEsp = (baseMax-tamano)/2;
            int caracteresFaltantes = caracteresPorDibujar(tamano);
            string espacioD;
            string espacioI = repetir(" ", numEsp);
            if (tamano%2 == 0) {
                espacioD = repetir(" ", numEsp + 1);
            } else {
                espacioD = espacioI;
            }
            char[,] arreglo = crearArregloChar(tamano, ' ');
            int dimensionX = arreglo.GetLength(0);
            int dimensionY = arreglo.GetLength(1);
            int posicionX = 0;
            int posicionY = 0;            
            if (true) {
                Console.WriteLine("|-------------------------------------------"
                                    + "|");
                Console.WriteLine("|                   ESPIRAL                 "
                                    + "|");
                Console.WriteLine("|-------------------------------------------"
                                    + "|");
                Console.WriteLine("|                                           "
                                    + "|");
                for (int i = 0; i < dimensionX; i++) {                   
                    arreglo.SetValue('\u2588',i,posicionY);
                    posicionX = i;
                }
                for (int i = 1; i < dimensionY; i++) {
                    arreglo.SetValue('\u2590',posicionX,i);
                    posicionY = i;
                }
                dimensionX--;
                dimensionY--;
                int contadores = 1;
                do
                {                                   
                    for (int i = 0; i <= dimensionX-contadores; i++) {
                        posicionX--;
                        caracteresFaltantes--;                                              
                        arreglo.SetValue('\u2588',posicionX,posicionY);                        
                    }           
                    contadores++;                           
                    if (caracteresFaltantes < 1) break;                        
                    for (int i = 0; i < dimensionY-contadores; i++) {
                        posicionY--;
                        caracteresFaltantes--;
                        arreglo.SetValue('\u258C',posicionX,posicionY);                       
                    } 
                    contadores++;             
                    if (caracteresFaltantes < 1) break;                    
                    for (int i = 0; i <= dimensionX-contadores; i++) {
                        posicionX++;
                        caracteresFaltantes--;
                        arreglo.SetValue('\u2588',posicionX,posicionY);                        
                    }   
                    contadores++;                                    
                    if (caracteresFaltantes < 1) break;                        
                    for (int i = 0; i < dimensionY-contadores; i++) {
                        posicionY++;
                        caracteresFaltantes--;
                        arreglo.SetValue('\u2590',posicionX,posicionY);                       
                    } 
                    contadores++;                          
                } while (caracteresFaltantes > 0);
                for (int pY = 0; pY < arreglo.GetLength(1); pY++){
                    Console.WriteLine($"| {espacioI}" + 
                                    $"{construirFila(arreglo, pY)}" + 
                                    $"{espacioD} |"); 
                }
                Console.WriteLine("|                                           "
                                    + "|");
                Console.WriteLine("|-------------------------------------------"
                                    + "|");
            }
        }

        public static int caracteresPorDibujar(int tamano) {
            tamano = tamano - 1;
            int acumulado = 0;
            int resto = 0;
            int conta = 0;
            do {
                resto = tamano - conta;
                acumulado = acumulado + resto;
                conta++;
            } while (resto > 0);
            return acumulado;
        }
        static void Main(string[] args)
        {
            string caracterFigura;
            string figura; 
            int tmn;
            Console.WriteLine("|-------------------------------------------|");
            Console.WriteLine("|               CREA TU FIGURA              |");
            Console.WriteLine("|-------------------------------------------|");
            Console.WriteLine("| INSTRUCCIONES:                            |");
            Console.WriteLine("| 1 - Escribe un carácter para generar la   |");
            Console.WriteLine("|     figura.                               |");
            Console.WriteLine("| 2 - Selecciona la figura (trianguo o      |");
            Console.WriteLine("|     espiral). Otra opción es triangulo    |");
            Console.WriteLine("|     iso el cual dibuja un triangulo sin   |");
            Console.WriteLine("|     espacios.                             |");
            Console.WriteLine("| 3 - Selecciona el tamaño de la figura.    |");
            Console.WriteLine("|     Toma en cuenta  que se trata de una   |");
            Console.WriteLine("|     figura cuadara por lo que la altura y |");
            Console.WriteLine("|     la anchura serán la misma.            |");
            Console.WriteLine("|-------------------------------------------|");
            Console.Write(" Caracter para figura: ");
            caracterFigura = Console.ReadLine().Trim();
            Console.Write(" Figura a generar: ");
            figura = Console.ReadLine();
            figura = figura.Trim().ToLower();;
            switch (figura) {
                 case "triangulo":
                    tmn = solicitaTamano("¿Cuántos carácteres tendrá el " 
                                            + "triangulo en la base?");
                    if (validaTamFig(figura, tmn)) {
                        triangulo(caracterFigura, tmn);
                    } else {
                        Console.Write("\n Lo siento solo puedo hacer un " + 
                                    "triangulo de base mayor a 1 y menor a 22."
                                    + " Intenta la próxima.");
                    }
                    break;
                case "triangulo iso":
                    tmn = solicitaTamano("¿Cuál será el tamaño de la base "
                                            + "del triangulo, si el número no" 
                                            + " es non se usará el número " 
                                            + "inferor non más cercano?");
                    if (validaTamFig(figura, tmn)) {
                        trianguloIso(caracterFigura, tmn);
                    } else {
                        Console.Write("\n Lo siento solo puedo hacer un " + 
                                    "triangulo de base mayor a 2 y menor a 42."
                                    + " Intenta la próxima.");
                    }
                    break;
                case "espiral":
                    tmn = solicitaTamano("¿Cuál será el tamaño de la base de" 
                                            + " la espiral?");
                    if (validaTamFig(figura, tmn)) {
                        espiral(caracterFigura, tmn);
                    } else {
                        Console.Write("\n Lo siento solo puedo hacer una " + 
                                    "espiral de base mayor a 4 y menor a 42."
                                    + " Intenta la próxima.");
                    }                                     
                    break;
                case "espiral magico":
                    tmn = solicitaTamano("¿Cuál será el tamaño de la base de" 
                                            + " la espiral?");
                    espiralMagico(tmn);
                    break;
                default: 
                    Console.Write("\n Lo siento solo puedo hacer un triangulo o"
                                    + " una espiral. Intenta la próxima.");
                    break;
            }
            Console.WriteLine("Presiona cualquier tecla para continuar ...");
            Console.ReadLine();
        }
    }
}