#include <algorithm>
#include <iterator>
#include <numeric>
#include "transport.h"

int lab2::paczka::sId=0;

std::ostream& lab2::operator<<(std::ostream& out, const paczka& paczka)
    {
    return out << "paczka " << paczka.id() << " : " << paczka.waga() << " kg";
    }

bool lab2::operator<(const lab2::paczka& p1, const lab2::paczka& p2) {
	return p1.id() - p2.id() < 0;
}

std::ostream& lab2::operator<<(std::ostream& out, const lab2::firma_transportowa& ft) {
	std::copy(ft.paczki.begin(), ft.paczki.end(), std::ostream_iterator<lab2::paczka>(out, ", "));
	return out;
}

void lab2::firma_transportowa::wyslij_ciezarowke() {
	lab2::ciezarowka nowaCiezarowka;
	std::copy(this->paczki.begin(), this->paczki.end(), std::back_inserter<vector<lab2::paczka>>(nowaCiezarowka.paczki));
	this->paczki.erase(this->paczki.begin(), this->paczki->end());
	this->ciezarowki.push_back(nowaCiezarowka);
}

const lab2::ciezarowka& lab2::firma_transportowa::nta_ciezarowka(int n) const {
	return this->ciezarowki[n];
}

lab2::ciezarowka& lab2::firma_transportowa::nta_ciezarowka(int n) {
	return this->ciezarowki[n];
}

std::ostream& lab2::operator<<(std::ostream& out, const lab2::ciezarowka& c) {
	out << "Ciezarowka ";
	std::copy(c.paczki.begin(), c.paczki.end(), std::ostream_iterator<lab2::paczka>(out, ", "));
	return out;
}
int lab2::ciezarowka::waga_paczek() const {
	return std::accumulate(this->paczki.begin(), this->paczki.end(), 0,
		[](int suma, const lab2::paczka& p) -> int { return suma + p.waga(); });
}