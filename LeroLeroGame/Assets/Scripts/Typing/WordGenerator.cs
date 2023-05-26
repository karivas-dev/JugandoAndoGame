using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] FalseBrand = {"marcas", "derecho exclusivo", "invencion", "comercio", "autor", 
                                            "creador", "obra", "libro", "musica", "tecnologia", 
                                            "empresas", "negocio", "signos distintivos", "logos", "nombre comercial", 
                                            "arte", "legislacion", "registro", "derecho", 
                                            "derecho de autor", "creacion", "bien protegido", "eslogan", "distintivo corporativo",
                                             "original", "producto", "titular", "licencia", "caducidad", "servicios", 
                                             "inmaterial", "clasificacion", "monopolio", 
                                             "vulneracion", "proteccion", "nacional", "comunitario", 
                                             "global", "internacional", "propiedad industrial", "propiedad intelectual", 
                                            "patentes", "industria", "leyes",
                                             "inventos", "marcas", "modelos", "propiedad"};

    public static string GetRandomWord()
    {
        int index = Random.Range(0, FalseBrand.Length);
        string randomBrand = FalseBrand[index];

        return randomBrand;
    }
    
}
