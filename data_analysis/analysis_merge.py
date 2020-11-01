import matplotlib.pyplot as plt
from dateutil.parser import parse
import time
import numpy as np
import os

# fig1,axes1=plt.subplots(1,2, figsize=(8, 3))
# fig1,(axes1, axes2, axes3) =plt.subplots(1,2)
# fig1, axes1 =plt.subplots(1,2, gridspec_kw = {'width_ratios':[2.5, 1]})
# fig2, axes2 =plt.subplots(1,2, gridspec_kw = {'width_ratios':[3.5, 1]})
fig3, axes3 =plt.subplots(1,2, gridspec_kw = {'width_ratios':[1, 1]})



all_data_group_utility = [[54, 48, 54, 54, 54, 54, 48, 54, 54, 54], \
						  [77, 78, 78, 82, 79, 77, 80, 78, 77, 79], \
						  [63, 65, 65, 57, 57, 57, 65, 64, 65, 65], \
						  [108, 108, 108, 108, 108, 108, 108, 108, 108, 108]]

all_data_energy_cost = [[13.44, 15.44, 13.50, 13.53, 13.49, 13.78, 15.06, 13.58, 13.69, 13.47], \
						[21.62, 20.86, 20.65, 20.73, 20.42, 20.94, 20.36, 20.59, 21.25, 21.03], \
						[17.75, 17.12, 17.45, 19.96, 19.83, 19.84, 17.42, 17.40, 17.39, 17.42], \
						[10.53, 10.42, 10.47, 10.43, 10.65, 10.63, 10.50, 10.40, 10.53, 10.50]]


labels5 = ['6C', '6O', '3C+3O\n(NC)', '3C+3O\n(C)']

bplot5 = axes3[0].boxplot(all_data_group_utility, \
					patch_artist=True, \
					labels=labels5, \
					widths = 0.5,\
					boxprops = {'color':'black','facecolor':'#9999ff'}, \
					flierprops = {'marker':'o','markerfacecolor':'white','color':'black'}, \
					whiskerprops = {'color':'black', 'linestyle':'-'})

for i in range(len(bplot5['boxes'])):
	if i == 0:
	    # change outline color
	    bplot5['boxes'][i].set(color='black', linewidth=2)
	    # change fill color
	    bplot5['boxes'][i].set(facecolor = 'green')
	    # change hatch
	    bplot5['boxes'][i].set(hatch = 'o')

	if i == 1:
	    # change outline color
	    bplot5['boxes'][i].set(color='black', linewidth=2)
	    # change fill color
	    bplot5['boxes'][i].set(facecolor = 'green')
	    # change hatch
	    bplot5['boxes'][i].set(hatch = '/')

	if i == 2:
	    # change outline color
	    bplot5['boxes'][i].set(color='black', linewidth=2)
	    # change fill color
	    bplot5['boxes'][i].set(facecolor = 'green')
	    # change hatch
	    bplot5['boxes'][i].set(hatch = 'x')

	if i == 3:
	    # change outline color
	    bplot5['boxes'][i].set(color='black', linewidth=2)
	    # change fill color
	    bplot5['boxes'][i].set(facecolor = 'green')
	    # change hatch
	    bplot5['boxes'][i].set(hatch = '.')

colors5 = ['purple', 'lightgreen', 'pink', 'red']
for patch, color in zip(bplot5['boxes'], colors5):
    patch.set_facecolor(color)

axes3[0].tick_params(top='off', right='off')
# plt.grid(axis='y', which='major')
# plt.xlabel('Three separate samples')
axes3[0].set_ylabel('The Amount Rescuers', fontsize=18)
# axes3[0].set_xlabel('(a-1)', fontsize=15)
axes3[0].tick_params('x', labelsize=11)

# distance vs collision
labels6 = ['6C', '6O', '3C+3O\n(NC)', '3C+3O\n(C)']

bplot6 = axes3[1].boxplot(all_data_energy_cost, \
					patch_artist=True, \
					labels=labels6, \
					widths = 0.5,\
					boxprops = {'color':'black','facecolor':'#9999ff'}, \
					flierprops = {'marker':'o','markerfacecolor':'white','color':'black'}, \
					whiskerprops = {'color':'black', 'linestyle':'-'})

for i in range(len(bplot6['boxes'])):
	if i == 0:
	    # change outline color
	    bplot6['boxes'][i].set(color='black', linewidth=2)
	    # change fill color
	    bplot6['boxes'][i].set(facecolor = 'green')
	    # change hatch
	    bplot6['boxes'][i].set(hatch = '/')

	if i == 1:
	    # change outline color
	    bplot6['boxes'][i].set(color='black', linewidth=2)
	    # change fill color
	    bplot6['boxes'][i].set(facecolor = 'green')
	    # change hatch
	    bplot6['boxes'][i].set(hatch = '+')

	if i == 2:
	    # change outline color
	    bplot6['boxes'][i].set(color='black', linewidth=2)
	    # change fill color
	    bplot6['boxes'][i].set(facecolor = 'green')
	    # change hatch
	    bplot6['boxes'][i].set(hatch = 'x')

	if i == 3:
	    # change outline color
	    bplot6['boxes'][i].set(color='black', linewidth=2)
	    # change fill color
	    bplot6['boxes'][i].set(facecolor = 'green')
	    # change hatch
	    bplot6['boxes'][i].set(hatch = '.')

colors6 = ['purple', 'lightgreen', 'pink', 'red']
for patch, color in zip(bplot6['boxes'], colors6):
    patch.set_facecolor(color)

axes3[1].tick_params(top='off', right='off')
# plt.grid(axis='y', which='major')
# plt.xlabel('Three separate samples')
axes3[1].set_ylabel('Ave NRG Cost Per Rescuing Unit', fontsize=17)
# axes3[1].set_xlabel('(a-2)', fontsize=15)
axes3[1].tick_params('x', labelsize=11)

plt.subplots_adjust(top=None, bottom=0.1, wspace=0.4)
plt.tight_layout()

plt.show()