#include "lab3.h"

#include <algorithm>
#include <iterator>

namespace lab3 {

void printVector(std::ostream &stream, const std::vector<int> &v)
{
    std::ostream_iterator<int> it(stream, " ");
    std::copy(v.begin(),v.end(), it);
    stream << std::endl;
}

//Tu implementujemy comparisonCountingSort

}
