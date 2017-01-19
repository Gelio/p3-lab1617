#include <iostream>
#include <list>
#include <vector>

#include "transport.h"

using lab2::firma_transportowa;
using lab2::ciezarowka;
using lab2::paczka;

int main(int argc, char** argv)
    {
    std::cout << std::endl << "*** Etap 1 (2p) ***" << std::endl << std::endl;

    firma_transportowa ft;
    const firma_transportowa& ftr=ft;

    const std::vector<paczka> p1= {paczka(2),paczka(3),paczka(2),paczka(12)};
    const std::list<paczka> p2= {paczka(5),paczka(13),paczka(21),paczka(8)};
    const paczka p3=12;

    ft.dodaj_paczke_do_kolejki(p3);
    ft.dodaj_paczki_do_kolejki(p1.begin(), p1.end());

    std::cout << ft << std::endl;

    std::cout << std::endl << "*** Etap 2 (1p) ***" << std::endl;

    ft.wyslij_ciezarowke();

    std::cout << ft << std::endl;

    std::cout << ftr.nta_ciezarowka(0) << std::endl;
    std::cout << ftr.nta_ciezarowka(0). waga_paczek() << std::endl;

    ft.dodaj_paczki_do_kolejki(p2.begin(), p2.end());

    ft.wyslij_ciezarowke();

    std::cout << ftr.nta_ciezarowka(1) << std::endl;
    std::cout << ftr.nta_ciezarowka(1). waga_paczek() << std::endl;

    const paczka p4=13;
    const paczka p5=11;
    const paczka p6=2;
    ft.dodaj_paczke_do_kolejki(p4);
    ft.dodaj_paczke_do_kolejki(p5);
    ft.dodaj_paczke_do_kolejki(p6);
    ft.wyslij_ciezarowke();

    std::cout << ftr.nta_ciezarowka(2) << std::endl;
    std::cout << ftr.nta_ciezarowka(2). waga_paczek() << std::endl;

    std::cout << std::endl << "*** Etap 3 (1p) ***" << std::endl << std::endl;

    //std::vector<ciezarowka> kopia = ft.kopia_ciezarowek();
    //std::cout << kopia << std::endl;
    //lab2::oproznij_niedopuszczone_ciezarowki(kopia);
    //std::cout << "Po wyczyszczeniu:\n" << kopia << std::endl;

    std::cout << std::endl << "*** Etap 4 (1p) ***" << std::endl << std::endl;

    //std::cout << "Przed wywazeniem\n" << ft.kopia_ciezarowek() << std::endl;
    //ft.nta_ciezarowka(0).popraw_wywazenie();
    //ft.nta_ciezarowka(1).popraw_wywazenie();
    //kopia=ft.kopia_ciezarowek();
    //std::cout << "Po wywazeniu\n" << kopia << std::endl;
    //std::cout << "Ciezarowka 2 po wywazeniu\n" << ftr.nta_ciezarowka(1) << std::endl;

    std::cout << std::endl << "*** Koniec ***" << std::endl << std::endl;
    return 0;
    }


