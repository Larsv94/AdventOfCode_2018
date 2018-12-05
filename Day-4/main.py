import re
from datetime import datetime, timedelta
from collections import Counter
from itertools import chain


def get_sorted_input():
    p = re.compile(r"^\[(?P<date>.*?)\] (?P<action>.+)$")
    with open("input.txt") as f:
        input_list = []
        for line in f:
            match = p.search(line)
            date = datetime.strptime(match.group("date"),"%Y-%m-%d %H:%M")

            if(date.hour > 1): #if the guard starts later than 1 o'clock we assume his shift starts tomorrow
                date = date + timedelta(days=1)
                date = date.replace(hour=0,minute=0)

            input_list.append((date,match.group("action")))
        
    input_list.sort()
    return input_list

def get_actions_per_day(input_list):
    day_list = {}
    #we build a dictionary with the month-day as key
    for item in input_list:
        day = f"{item[0].month}-{item[0].day}"
        action = (item[0].minute,item[1])

        #we add each action to a list at the appropriate day
        if day in day_list:
            day_list[day].append(action)
        else:
            day_list[day] = [action]
    return day_list

def get_guard_schedules(day_list):
    p_guardID = re.compile(r"(\d+)")

    guard_schedule = {}

    for k in day_list.keys(): 
        day = day_list[k]

        guard_ID = int(p_guardID.search(day[0][1]).group())

        if guard_ID not in guard_schedule:
            guard_schedule[guard_ID] = {'times':[],'total_sleep':0}
        
        for i in range(1,len(day)-1,2):
            guard_schedule[guard_ID]['times'].append(range(day[i][0],day[i+1][0]))
            guard_schedule[guard_ID]['total_sleep']+=day[i+1][0]-day[i][0]

    return guard_schedule


sorted_input = get_sorted_input()
action_list = get_actions_per_day(sorted_input)
guard_schedule=get_guard_schedules(action_list)


for guard in guard_schedule:
        guard_schedule[guard]['most_slept'] = (-1,-1)#intialize most_slept key
        if len(guard_schedule[guard]['times']) >0:
            totals = Counter(chain.from_iterable(guard_schedule[guard]['times']))
            guard_schedule[guard]['most_slept']=totals.most_common(1)[0]

 
laziest = sorted(guard_schedule.items(), key=lambda x: x[1]['total_sleep'],reverse=True)[0]

most_asleep_at = sorted(guard_schedule.items(), key=lambda x:x[1]['most_slept'][1] ,reverse=True)[0]
   
print(f'Guard #{laziest[0]} was the sleepiest')#challenge 1
print(laziest[1]['most_slept'][0] *  laziest[0])
print()
print(f'Guard #{most_asleep_at[0]} was the most asleep at a certain time')#challenge 2
print( most_asleep_at[1]['most_slept'][0] *  most_asleep_at[0])
    

