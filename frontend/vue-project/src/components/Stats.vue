<script setup>
    import ProgressBar from './ProgressBar.vue';
</script>

<template>
    <div class="stats">
        <div>
            <h1>hp</h1>
            <ProgressBar
                :color="hp"
                :percent="pokemon.hp"/>
        </div>
        <div>
            <h1>attack</h1>          
            <ProgressBar
                :color="attack"
                :percent="pokemon.attack"/>
        </div>
        <div>
            <h1>defense</h1>
            <ProgressBar
                :color="defense"
                :percent="pokemon.defense"/>
        </div>
        <div>
            <h1>special-attack</h1>
            <ProgressBar
                :color="specialAttack"
                :percent="pokemon.specialAttack"/>
        </div>
        <div>
            <h1>special-defense</h1>
            <ProgressBar
                :color="specialDefense"
                :percent="pokemon.specialDefense"/>
        </div>
        <div>
            <h1>speed</h1>
            <ProgressBar
                :color="speed"
                :percent="pokemon.speed"/>
        </div>
            
    </div>
</template>

<script>
    export default {
        props: {
            pokemon: {
                type: Object,
                default: null
            }
        },
        data () {
            return {
                types: [],
                hp: '#00FF00',
                attack: '#FF0000',
                defense: '#0000FF',
                specialAttack: '#800000',
                specialDefense: '#000080',
                speed: '#FFFF00',
                accuracy: '#D2691E',
                evasion: '#6A5ACD',
                percent: 30,
            }
        },
        mounted(){
            for(let i = 0; i < this.pokemon.types.length; i++){
                this.types.push({
                    name: this.pokemon.types[i],
                    color: types[this.pokemon.types[i]][0],
                    textcolor: types[this.pokemon.types[i]][1]
                });
            }
            console.log(this.pokemon)
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