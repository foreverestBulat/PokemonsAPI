<script setup>
    import { RouterLink } from 'vue-router';
</script>

<template>
    <!-- <div> -->
    <RouterLink :to="{ name: 'pokemon', params: {id: pokemon.id }}">
        <div class="card">
            <div class="top">
                <div class="name">{{ pokemon.name }}</div>
                <div class="number">#{{ pokemon.id }}</div>
            </div>
            <img :src="pokemon.image"/>
            <div class="down" v-if="typesColors.length != 0">
                <!-- <div v-for="type in pokemon.types">
                    <p>{{ type }}</p>
                </div> -->
                <!-- :style="{ 'background-color': typesColors[0].color, 'color': typesColors[0].textcolor }" -->
                <!-- <div :style="{ backgroundColor: typesColors[0].color, color: typesColors[0].textcolor }"> -->
                
                <div :style="{ backgroundColor: typesColors[0].color, color: typesColors[0].textcolor }">
                    <p>{{ pokemon.types[0] }}</p>
                </div>
                <div v-if="pokemon.types.length > 1 && typesColors.length > 1" :style="{ backgroundColor: typesColors[1].color, color: typesColors[1].textcolor }">
                    {{ pokemon.types[1] }}
                </div>
            </div>
        </div>
    </RouterLink>
    <!-- </div> -->
</template>

<script>
    export default {
        data () {
            return {
                typesColors: [],
            }
        },
        props: {
            pokemon: {
                type: Object,
                default: null
            }
        },
        mounted(){
            for(let i = 0; i < this.pokemon.types.length; i++){
                this.typesColors.push({
                    name: this.pokemon.types[i],
                    color: types[this.pokemon.types[i]][0],
                    textcolor: types[this.pokemon.types[i]][1]
                });
            }
        }
    }

    const types = {
        'normal': ['#A52A2A', 'white'],
        'fighting': ['#FFA500', 'white'],
        'flying': ['#5F9EA0', 'white'],
        'poison': ['#9400D3', 'white'],
        'ground': ['#D2691E', 'white'],
        'rock': ['#8B4513', 'white'],
        'bug': ['#006400', 'white'],
        'ghost': ['#483D8B', 'white'],
        'steel': ['#00FF7F', 'white'],
        'fire': ['#FF0000', 'white'],
        'water': ['#0000FF', 'white'],
        'grass': ['#008000', 'white'],
        'electric': ['#FFFF00', 'black'],
        'phychic': ['#DB7093', 'black'],
        'ice': ['#ADD8E6', 'white'],
        'dragon': ['#00FFFF', 'white'],
        'dark': ['#000000', 'white'],
        'fairy': ['#DC143C', 'white'],
        'unknown': ['#A9A9A9', 'white'],
        'shadow': ['#191970', 'white']
    }
</script>

