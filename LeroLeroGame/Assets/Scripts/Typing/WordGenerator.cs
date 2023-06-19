using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] FalseBrand = {"marcas", "derecho exclusivo", "cnr", "comercio", "autor", 
                                            "creador", "obra", "libro", "ompi", "software", 
                                            "empresas", "negocio", "signos distintivos", "logos", "nombre comercial", 
                                            "arte", "hardware", "registro", "derecho", 
                                            "derecho de autor", "idea", "bien protegido", "eslogan", "distintivo corporativo",
                                             "original", "producto", "titular", "licencia", "caducidad", "servicios", 
                                             "inmaterial", "creador", "monopolio", 
                                             "robo", "seguridad", "nacional", "comunitario", 
                                             "global", "internacional", "propiedad industrial", "propiedad intelectual", 
                                            "patentes", "industria", "leyes",
                                             "inventos", "autenticidad", "modelos", "propiedad"};

    public static string GetRandomWord()
    {
        int index = Random.Range(0, FalseBrand.Length);
        string randomBrand = FalseBrand[index];

        return randomBrand;
    }
    
}
