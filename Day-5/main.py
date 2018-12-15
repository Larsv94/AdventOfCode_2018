input_str1 = ''

def matchPolymer(char1, char2):
    if char1.isupper(): # if U then char2 = u
        return char1.lower() == char2
    else: # if u then char2 = U
        return char1.upper() == char2

with open('input.txt') as f:
    input_str1 = f.readline()#input is only one line

def pop_str(x):
    if not x : return '',''
    return x[:-1], x[-1]

def find_next_match(polymer):
    for i in range(1,len(polymer)):
        if matchPolymer(polymer[i-1],polymer[i]):
            return i
    return len(polymer)

def split_poly(temp,poly,index):
    if index == 1:
        split = poly[2:]
        temp,pop = pop_str(temp)
        return temp,pop+split
    else:
        return temp+poly[:index-1],poly[index+1:]


def react_polymer(input_poly):
    temp_poly = ''
    curr_poly = input_poly
    searching = True
    while(searching):
        # print(f'temp = {temp_poly} :: curr = {curr_poly}')
        nextMatch = find_next_match(curr_poly)
        if nextMatch >= len(curr_poly):
            if not temp_poly:
                temp_poly+=curr_poly
                break
            else:
                curr_poly=temp_poly+curr_poly
                temp_poly=''
        else:
            temp_poly,curr_poly = split_poly(temp_poly,curr_poly,nextMatch)
    return temp_poly



answer = react_polymer(input_str1)

print('============= Answer 1 =============')
print(answer)
print(len(answer))

def get_unique_components(poly):
    return list(set(poly.lower()))
    
components = get_unique_components(answer)

min_length = len(answer)
char=''

for comp in components:
    new_poly = answer.replace(comp,'').replace(comp.upper(),'')
    new_len = len(react_polymer(new_poly))
    if new_len<min_length:
        min_length=new_len
        char=comp


print('============= Answer 2 =============')

print(min_length)
print(char)