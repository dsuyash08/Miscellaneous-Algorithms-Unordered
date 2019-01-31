synonyms_dict = {'come' : ['approach', 'advance', 'near', 'arrive', 'reach'],
  'show' : ['display', 'exhibit', 'present', 'point to', 'indicate', 'explain', 'reveal', 'prove', 'demonstrate', 'expose'],
  'good' : ['excellent', 'fine', 'superior', 'wonderful', 'grand', 'superb', 'edifying'],
  'bad' : ['evil', 'immoral', 'wicked', 'contaminated', 'spoiled', 'defective',  'substandard', 'faulty', 'improper', 'inappropriate']
}
def remove_short_synonyms(synonyms_dict):
   for i in {'a', 'b', 'c'}:
      print(i, end=' ')


print(remove_short_synonyms(synonyms_dict))