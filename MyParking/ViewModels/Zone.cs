using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MyParking.ViewModels
{
    public enum Zones
    {
        [Display(Name = "Strada Baba Novac")]
        Baba_Novac,

        [Display(Name = "Emil Isac")]
        Emil_Isac,

        [Display(Name = "Bulevardul Eroilor")]
        Bulevardul_Eroilor,

        [Display(Name = "Strada Iuliu Maniu")]
        Iuliu_Maniu,

        [Display(Name = "Strada Mamaia")]
        Mamaia,

        [Display(Name = "Calea Dorobantilor")]
        Calea_Dorobantilor,

        [Display(Name = "Strada Nicolae Titulescu")]
        Nicolae_Titulescu,

        [Display(Name = "Strada Dragalina")]
        Dragalina,

        [Display(Name = "Strada Lucian Blaga")]
        Lucian_Blaga,

        [Display(Name = "Piata Cipariu")]
        Piata_Cipariu,

        [Display(Name = "Strada Ploiesti")]
        Ploiesti,

        [Display(Name = "Strada Fabricii")]
        Fabricii,

        [Display(Name = "Strada Primaverii")]
        Primaverii,

        [Display(Name = "Strada Mehedinti")]
        Mehedinti,

        [Display(Name = "Strada Negoiu")]
        Negoiu,

        [Display(Name = "Strada Traian Vuia")]
        Traian_Vuia,

        [Display(Name = "Aleea Azuga")]
        Aleea_Azuga,

        [Display(Name = "Aleea Baisoara")]
        Aleea_Baisoara,

        [Display(Name = "Strada Nicolae Pascaly")]
        Nicolae_Pascaly,

        [Display(Name = "Piata Mihai Viteazu")]
        Mihai_Viteazu
    };
}