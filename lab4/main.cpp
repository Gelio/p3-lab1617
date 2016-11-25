#include <iostream>
#include <algorithm>
#include <iterator>
#include <ostream>

#include "mailchess.h"

using std::cout;
using std::endl;
using std::vector;

using lab4::chess_mail_problem;
using lab4::player_pair;

static int count_max_color_count(const vector<int>& envelope_colors, int color_count)
    {
    vector<int> counts(color_count, 0);
    for(int c : envelope_colors)
        {
        counts[c]++;
        }
    return *std::max_element(counts.begin(), counts.end());
    }

static std::ostream& operator<<(std::ostream& out, const std::vector<int>& v)
    {
    std::copy(v.begin(), v.end(), std::ostream_iterator<int>(out, " "));
    return out;
    }

#define TEST_CHECKER(description, expr, expected, counter) { \
    bool result = expr; \
    cout << "Test (" description") wynik " << result << " oczekiwano " << expected << endl; \
    counter += result==expected? 1:0;				\
}

#define TEST(problem, colors, expected, counter) {	\
    vector<int> solution;\
    bool success = true;\
    bool result = lab4::is_number_of_colors_enough(problem, colors, solution);\
    cout << "Test " #problem " " << colors << " kolorow. Oczekiwany wynik " << expected << " wyliczony " << result << endl;\
    if(result){\
      bool ver = lab4::check_envelope_colors(problem, solution, colors);\
      success = ver;\
      cout << "Otrzymany wektor: " << solution << endl;\
      cout << "Weryfikacja rozwiazania z 1 etapu: " << ver << endl;\
    }\
    cout << "** Test " << (success&&result==expected ? "pozytywny" : "negatywny") << endl << endl; \
    counter += success&&result==expected? 1:0;\
}

#define TEST_OPT(problem, colors, expected, expected_count, counter) {	\
    vector<int> solution;\
    bool success = true;\
    int count;\
    bool result = lab4::is_number_of_colors_enough_best_solution(problem, colors, solution, count); \
    cout << "Test " #problem " " << colors << " kolorow. Oczekiwany wynik " << expected << " wyliczony " << result << endl;\
    if(result){\
      int colors_ver = count_max_color_count(solution, colors);\
      cout << "Otrzymany wektor: " << solution << endl;\
      cout << " Oczekiwana max(liczba_koloru): " << expected_count << " raportowana " << count << " faktyczna: " << colors_ver << endl; \
      bool ver = lab4::check_envelope_colors(problem, solution, colors);\
      success = ver && count==expected_count&& count==colors_ver;\
      cout << "Weryfikacja rozwiazania z 1 etapu: " << ver << endl;\
    }\
    cout << "** Test " << (success&&result==expected ? "pozytywny" : "negatywny") << endl << endl; \
    counter += success&&result==expected? 1:0;				\
}


static std::vector<player_pair> star(int players, int center)
    {
    std::vector<player_pair> ret;
    for(int i=0; i<players; i++)
        {
        if(i!=center)
            {
            ret.push_back(player_pair(i,center));
            }
        }
    return ret;
    }

static std::vector<player_pair> grid(int w, int h)
    {
    std::vector<player_pair> ret;

    for(int i=0; i<w; i++)
        {
        for(int j=0; j<h; j++)
            {
            if(j<h-1)
                {
                ret.push_back(player_pair(i*h+j, i*h+j+1));
                }
            if(i<w-1)
                {
                ret.push_back(player_pair(i*h+j, (i+1)*h+j));
                }
            }
        }

    return ret;
    }

int main(int argc, char** argv)
    {
    const chess_mail_problem p1 = chess_mail_problem(
                                      3,
        {player_pair(0,1), player_pair(1,2)},
    10
                                  );

    const chess_mail_problem p2 = chess_mail_problem(
                                      4,
        {player_pair(0,3), player_pair(1,2)},
    1
                                  );

    cout << endl;

    cout << "++ Etap 1 (1 punkt)" << endl << endl;
    int passed=0;

    TEST_CHECKER("ok", lab4::check_envelope_colors(p2, {0,1}, 2), 1, passed);
    TEST_CHECKER("ok", lab4::check_envelope_colors(p1, {0,1}, 2), 1, passed);
    TEST_CHECKER("konflikt kolorow", lab4::check_envelope_colors(p1, {0,0}, 1), 0, passed);
    TEST_CHECKER("zly rozmiar wektora", lab4::check_envelope_colors(p1, {0}, 1), 0, passed);
    TEST_CHECKER("zly rozmiar wektora", lab4::check_envelope_colors(p1, {0,1,1}, 2), 0, passed);
    TEST_CHECKER("kolor spoza zakresu", lab4::check_envelope_colors(p1, {-1,0}, 1), 0, passed);
    TEST_CHECKER("kolor spoza zakresu", lab4::check_envelope_colors(p1, {0,1}, 1), 0, passed);
    TEST_CHECKER("uzycie kopert ponad limit produkcji", lab4::check_envelope_colors(p2, {0,0}, 1), 0, passed);
    cout << endl;
    cout << "++ Etap 1: Podsumowanie testow " << passed << "/8" << endl;
    cout << endl;

    cout << "++ Etap 2 (3 punkty)" << endl << endl;
    passed=0;

    const chess_mail_problem p3 = chess_mail_problem(
                                      10,
        {
        player_pair(0,1), player_pair(0,2), player_pair(0,3),
        player_pair(1,3), player_pair(3,4), player_pair(4,5),
        player_pair(5,6), player_pair(5,7), player_pair(6,9),
        player_pair(7,8), player_pair(8,9)
        },
    4
                                  );

    const chess_mail_problem p4 = chess_mail_problem(
                                      10,
        {
        player_pair(0,1), player_pair(0,2), player_pair(0,3),
        player_pair(1,3), player_pair(3,4), player_pair(4,5),
        player_pair(5,6), player_pair(5,7), player_pair(6,9),
        player_pair(7,8), player_pair(8,9)
        },
    3
                                  );


    TEST(p1,1,false, passed);
    TEST(p1,2,true, passed);
    TEST(p2,1,false, passed);
    TEST(p2,2,true, passed);
    TEST(p3,2,false, passed);
    TEST(p3,3,true, passed);
    TEST(p4,3,false, passed);
    TEST(p4,4,true, passed);
    TEST(chess_mail_problem(6,star(6,0),5),5,true, passed);
    TEST(chess_mail_problem(6,star(6,0),5),4,false, passed);
    TEST(chess_mail_problem(9,grid(3,3),5),4,true, passed);
    TEST(chess_mail_problem(9,grid(3,3),5),3,false, passed);
    TEST(chess_mail_problem(9,grid(3,3),2),4,false, passed);
    cout << "++ Etap 2: Podsumowanie testow " << passed << "/13" << endl;
    cout << endl;

    //cout << "++ Etap 3 -- minimalizacja 1p" << endl << endl;
    //passed=0;

    //TEST_OPT(p3,2,false,-1, passed);
    //TEST_OPT(p3,3,true, 4, passed);
    //TEST_OPT(p4,3,false,-1, passed);
    //TEST_OPT(p4,4,true, 3, passed);
    //TEST_OPT(p4,5,true, 3, passed);
    //TEST_OPT(p4,6,true, 2, passed);
    //TEST_OPT(chess_mail_problem(6,star(6,0),5),5,true,1, passed);
    //TEST_OPT(chess_mail_problem(6,star(6,0),5),4,false,-1, passed);
    //TEST_OPT(chess_mail_problem(9,grid(3,3),5),4,true, 3, passed);
    //TEST_OPT(chess_mail_problem(9,grid(3,3),5),3,false, -1, passed);
    //TEST_OPT(chess_mail_problem(9,grid(3,3),2),4,false, -1, passed);
    //cout << "++ Etap 3: Podsumowanie testow " << passed << "/11" << endl;


    //cout << endl;

    //cout << "++ Etap 4 (szybkosc dzialania - 1 punkt bonusowy)" << endl << endl;
    //passed=0;
    //TEST_OPT(p4,11,true, 1, passed);
    //TEST(p2, 5000, true, passed);
    //TEST_OPT(p4,5000,true, 1, passed);
    //TEST(chess_mail_problem(100, star(100,0), 1), 99, true, passed);
    //TEST_OPT(chess_mail_problem(100, star(100,0), 1), 99, true,1, passed);
    //cout << "++ Etap 4: Podsumowanie testow " << passed << "/5" << endl;

    //cout << endl;
    return 0;
    }

