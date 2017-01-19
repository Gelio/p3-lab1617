#ifndef TRANSPORT_H
#define TRANSPORT_H

#include <vector>
#include <set>
#include <ostream>
#include <algorithm>

using std::vector;
using std::set;

namespace lab2
{
class paczka
    {
        static int sId;
        int i;
        int w;

    public:
        inline int id() const
            {
            return i;
            }
        inline int waga() const
            {
            return w;
            }
        inline paczka(int waga) : i(sId++), w(waga) {}

		friend bool operator<(const paczka& p1, const paczka& p2);
    };

class ciezarowka
    {
    public:
        vector<paczka> paczki;
		int waga_paczek() const;

		friend std::ostream& operator<<(std::ostream& out, const ciezarowka& c);

    };

std::ostream& operator<<(std::ostream& out, const paczka& paczka);              // gotowe

class firma_transportowa
    {
        vector<ciezarowka> ciezarowki;
        set<paczka> paczki;

    public:
        template <class iter> void dodaj_paczki_do_kolejki(iter begin, const iter& end)
            {
				for_each(begin, end, [this](const paczka& p) { this->paczki.insert(p); });
            }
		
		void dodaj_paczke_do_kolejki(const paczka& p) {
			paczki.insert(p);
		}

		void wyslij_ciezarowke();
		const ciezarowka& nta_ciezarowka(int n) const;
		ciezarowka& nta_ciezarowka(int n);

		friend std::ostream& operator<<(std::ostream& out, const firma_transportowa& ft);

        // Dodać potrzebne składowe
    };

}


#endif


