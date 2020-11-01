import matplotlib.pyplot as plt
from dateutil.parser import parse
import time
import numpy as np
import os

all_data = [[54, 48, 54, 54, 54, 54, 48, 54, 54, 54], \
			[77, 78, 78, 82, 79, 77, 80, 78, 77, 79], \
			[108, 108, 108, 108, 108, 108, 108, 108, 108, 108]]

# draw the Per Task Negotiation Energy Cost graph
labels = ['$6~Car$', '$6~Obs$', '$3~Car+3~Obs$']

bplot = plt.boxplot(all_data, \
					patch_artist=True, \
					labels=labels, \
					boxprops = {'color':'black','facecolor':'#9999ff'}, \
					flierprops = {'marker':'o','markerfacecolor':'white','color':'black'}, \
					whiskerprops = {'color':'black', 'linestyle':'-'})

for i in range(len(bplot['boxes'])):
	if i == 0:
	    # change outline color
	    bplot['boxes'][i].set(color='black', linewidth=2)
	    # change fill color
	    bplot['boxes'][i].set(facecolor = 'green')
	    # change hatch
	    bplot['boxes'][i].set(hatch = 'o')

	if i == 1:
	    # change outline color
	    bplot['boxes'][i].set(color='black', linewidth=2)
	    # change fill color
	    bplot['boxes'][i].set(facecolor = 'green')
	    # change hatch
	    bplot['boxes'][i].set(hatch = '/')

	if i == 2:
	    # change outline color
	    bplot['boxes'][i].set(color='black', linewidth=2)
	    # change fill color
	    bplot['boxes'][i].set(facecolor = 'green')
	    # change hatch
	    bplot['boxes'][i].set(hatch = 'x')

	# if i == 3:
	#     # change outline color
	#     bplot['boxes'][i].set(color='black', linewidth=2)
	#     # change fill color
	#     bplot['boxes'][i].set(facecolor = 'green')
	#     # change hatch
	#     bplot['boxes'][i].set(hatch = '.')

# plt.title('Per Task Negotiation Energy Cost', fontsize=20)

colors = ['purple', 'lightgreen', 'pink', 'red']
for patch, color in zip(bplot['boxes'], colors):
    patch.set_facecolor(color)

plt.tick_params(top='off', right='off')
# plt.grid(axis='y', which='major')
# plt.xlabel('Three separate samples')
plt.ylabel('The Amount Rescuers', fontsize=18)
plt.xticks(fontsize = 15)
plt.show()