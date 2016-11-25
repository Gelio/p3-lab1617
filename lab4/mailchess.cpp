#include <set>
#include "mailchess.h"

using std::set;
using namespace lab4;


bool lab4::check_envelope_colors(const chess_mail_problem& problem, const vector<int>& envelope_colors, int number_of_colors) {
	if (problem.player_pairs.size() != envelope_colors.size())
		return false;

	vector<int> envelopesPerColor(number_of_colors);
	fill(envelopesPerColor.begin(), envelopesPerColor.end(), 0);
	bool hasInvalidColor = false;

	for_each(envelope_colors.begin(), envelope_colors.end(), [&envelopesPerColor, number_of_colors, &hasInvalidColor](int color) {
		if (color < 0 || color >= number_of_colors) {
			hasInvalidColor = true;
			return;
		}

		envelopesPerColor[color]++;
	});
	if (hasInvalidColor)
		return false;

	for_each(envelopesPerColor.begin(), envelopesPerColor.end(), [&problem, &hasInvalidColor](int envelopeAmount) {
		if (envelopeAmount > problem.envelope_production_limit)
			hasInvalidColor = true;
	});
	if (hasInvalidColor)
		return false;

	vector<set<int>> colorsUsedPerPlayer(problem.player_count);
	int player1, player2, color;
	for (int i = 0; i < envelope_colors.size(); i++) {
		player1 = problem.player_pairs[i].player1;
		player2 = problem.player_pairs[i].player2;
		color = envelope_colors[i];
		if (colorsUsedPerPlayer[player1].find(color) != colorsUsedPerPlayer[player1].end())
			return false;
		if (colorsUsedPerPlayer[player2].find(color) != colorsUsedPerPlayer[player2].end())
			return false;

		colorsUsedPerPlayer[player1].insert(color);
		colorsUsedPerPlayer[player2].insert(color);
	}
	return true;
}
bool lab4::check_envelope_colors2(const chess_mail_problem& problem, const vector<int>& envelope_colors, int number_of_colors) {
	vector<int> envelopesPerColor(number_of_colors);
	fill(envelopesPerColor.begin(), envelopesPerColor.end(), 0);
	bool hasInvalidColor = false;

	for_each(envelope_colors.begin(), envelope_colors.end(), [&envelopesPerColor, number_of_colors, &hasInvalidColor](int color) {
		if (color < 0 || color >= number_of_colors) {
			hasInvalidColor = true;
			return;
		}

		envelopesPerColor[color]++;
	});
	if (hasInvalidColor)
		return false;

	for_each(envelopesPerColor.begin(), envelopesPerColor.end(), [&problem, &hasInvalidColor](int envelopeAmount) {
		if (envelopeAmount > problem.envelope_production_limit)
			hasInvalidColor = true;
	});
	if (hasInvalidColor)
		return false;

	vector<set<int>> colorsUsedPerPlayer(problem.player_count);
	int player1, player2, color;
	for (int i = 0; i < envelope_colors.size(); i++) {
		player1 = problem.player_pairs[i].player1;
		player2 = problem.player_pairs[i].player2;
		color = envelope_colors[i];
		if (colorsUsedPerPlayer[player1].find(color) != colorsUsedPerPlayer[player1].end())
			return false;
		if (colorsUsedPerPlayer[player2].find(color) != colorsUsedPerPlayer[player2].end())
			return false;

		colorsUsedPerPlayer[player1].insert(color);
		colorsUsedPerPlayer[player2].insert(color);
	}
	return true;
}

bool lab4::is_number_of_colors_enough(const chess_mail_problem& problem, int number_of_colors, vector<int>& envelope_colors) {
	auto generated = generateSolution(problem, number_of_colors, vector<int>());
	envelope_colors = generated;
	return generated.size() == problem.player_pairs.size();
}

vector<int> lab4::generateSolution(const chess_mail_problem& problem, int number_of_colors, vector<int> valid_envelopes) {
	if (valid_envelopes.size() == problem.player_pairs.size())
		return valid_envelopes;

	for (int i = 0; i < number_of_colors; i++) {
		vector<int> temp = valid_envelopes;
		temp.push_back(i);

		if (check_envelope_colors2(problem, temp, number_of_colors)) {
			auto generated = generateSolution(problem, number_of_colors, temp);
			if (generated.size() == problem.player_pairs.size())
				return generated;
		}
	}

	return valid_envelopes;
}