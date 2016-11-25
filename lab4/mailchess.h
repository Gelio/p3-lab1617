#ifndef MAILCHESS_H
#define MAILCHESS_H

#include <ostream>
#include <vector>
#include <map>
#include <utility>
#include <algorithm>

using std::vector;
using std::map;
using std::pair;
using std::ostream;
using std::min;
using std::max;

namespace lab4
{
struct player_pair
    {
    int player1;
    int player2;

    player_pair(int player1, int player2) : player1(min(player1,player2)), player2(max(player1, player2)) {}
    };

struct chess_mail_problem
    {
    int player_count;
    std::vector<player_pair> player_pairs;
    int envelope_production_limit;

    chess_mail_problem(int player_count, const std::vector<player_pair>& player_pairs, int envelope_production_limit)
        : player_count(player_count), player_pairs(player_pairs), envelope_production_limit(envelope_production_limit) {}
    };

bool check_envelope_colors(const chess_mail_problem& problem, const vector<int>& envelope_colors, int number_of_colors);
bool check_envelope_colors2(const chess_mail_problem& problem, const vector<int>& envelope_colors, int number_of_colors);
bool is_number_of_colors_enough(const chess_mail_problem& problem, int number_of_colors, vector<int>& envelope_colors);
vector<int> generateSolution(const chess_mail_problem& problem, int number_of_colors, vector<int> valid_envelopes);

bool is_number_of_colors_enough_best_solution(const chess_mail_problem& problem, int number_of_colors, vector<int>& best_envelope_colors, int& max_color_count);

}

#endif /* MAILCHESS_H */

