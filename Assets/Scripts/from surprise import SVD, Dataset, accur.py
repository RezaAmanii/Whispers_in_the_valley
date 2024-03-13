from surprise import SVD, Dataset, accuracy, NormalPredictor, SlopeOne
from surprise.model_selection import train_test_split
from surprise.model_selection import cross_validate
import pandas as pd
import numpy as numpy

def train_and_evaluate(alg, data):
    trainset, testset = train_test_split(data, test_size=0.25)
    alg.fit(trainset)
    predictions = alg.test(testset)
    return cross_validate(alg, data, measures=['RMSE', 'MAE'], cv=5, verbose=False)

def compare_algs(alg1, alg2):

    print(f'Comparing RMSE for prediction algorithms {alg1.__class__.__name__} and {alg2.__class__.__name__}...')

    data = Dataset.load_builtin('ml-100k')

    alg1_result = train_and_evaluate(alg1, data)
    alg2_result = train_and_evaluate(alg2, data)

    alg1_rmse_avg = numpy.average(alg1_result['test_rmse'])
    alg2_rmse_avg = numpy.average(alg2_result['test_rmse'])
    #här kan man lägga till samma fast med en till metrik
    print(f'averge RMSE for {alg1.__class__.__name__} is', alg1_rmse_avg)
    print(f'averge RMSE for {alg2.__class__.__name__} is', alg2_rmse_avg)


    if (alg1_rmse_avg > alg2_rmse_avg):
        print(f'Average RMSE for {alg1.__class__.__name__} is larger than for {alg2.__class__.__name__}')
    elif (alg2_rmse_avg > alg1_rmse_avg):
        print(f'Average RMSE for {alg2.__class__.__name__} is larger than for {alg1.__class__.__name__}')
    else:
        print('Average RMSE for both algorithms same')


def main():
    compare_algs(SVD(), NormalPredictor())
    compare_algs(SlopeOne(), NormalPredictor())
    compare_algs(SlopeOne(), SVD())
    
if __name__ == "__main__":
    main()
