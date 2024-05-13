<script setup>
    import Card from '../components/Card.vue';
    import Search from '../components/Search.vue';
</script>

<template>
    <Search @search-name="searchName"/>
    <div class="cards">
        <Card v-for="pokemon in pokemons" :pokemon="pokemon"/>
    </div>
</template>

<script>
    import {getPokemons} from '../services/api.service.js';
    export default {
        data () {
            return {
                search: null,
                pokemons: []
            }
        },
        async mounted() {
            this.pokemons = await getPokemons(0, 20);
        },
        methods:{
            async searchName(value) {
                this.pokemons = await getPokemons(0, 20, value.name)
            }
        }
    }
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Quicksand:wght@300..700&display=swap');
.cards {
    display: flex;
    justify-content: center;
    flex-wrap: wrap;
}

a {
  text-decoration: none;
}

.no-pokemons {
    font-family: "Quicksand", sans-serif;
    font-optical-sizing: auto;
    font-weight: 600;
    font-style: normal;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
    height: 600px;
}

.no-pokemons h1 {
    font-size: 50px;
}

.no-pokemons .message {
    width: 300px;
    font-size: 30px;
    font-weight: 500;
}

.card {
    width: 200px;
    height: 250px;
    border-radius: 20px;
    box-shadow: 0px 5px 10px 0px rgba(0, 0, 0, 0.5);
    margin: 20px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
    padding: 20px;
    font-size: 20px;
    font-family: "Quicksand", sans-serif;
}

.card .top {
    display: flex;
    direction: column;
    justify-content: center;
}

.card .top .name {
    color: blue;
    margin-right: 30px;
}

.card img {
    width: 120px;
}

.card .down {
    display: flex;
    flex-direction: row;
}

.card .down div {
    /* background-color: rgb(220, 220, 220); */
    align-items: center;
    display: flex;
    justify-content: center;
    font-family: "Quicksand", sans-serif;
    width: 100px;
    height: 30px;
    border: none;
    border-radius: 10px;
    margin: 5px;
    font-size: 15px;
}
</style>