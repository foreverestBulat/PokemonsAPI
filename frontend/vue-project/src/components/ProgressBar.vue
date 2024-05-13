<template>
    <div class="progress-bar" :style="{'background-color': 'lightgray', 'height': '5px', 'width': '150px', 'border-radius': '5px', 'overflow': 'hidden'}">
        <div class="progress" :style="{'height': '100%', 'width': `${percent}%`, 'background-color': color }"></div>

        <!-- :style="{height: '100%', width: percent + '%', backgroundColor: color }" -->
    </div>
</template>

<script>
    export default {
        // props: ['percentBar', 'colorBar']
        // data (){
        //     return {
        //         percentBar: 50,
        //         colorBar: 'red'
        //     }
        // },
        props: {
            color: {
                type: String,
                default: '#000000'
            },
            percent: {
                type: Number,
                default: 50
            }
        },

    }
</script>

<!-- <style scoped>

.progress-bar {
    background-color: 'lightgray'; 
    height: 5px; 
    width: 150px;
    border-radius: '5px'; 
    overflow: 'hidden'
}

.progress {
    height: '100%'; 
    width: 40%; 
    background-color: #de0000;
}

/* v-bind('percent') */
/* background-color: v-bind('color'); */

/* #scriptSetup {
    color: v-bind('colorFromScriptSetup')
} */
</style> -->