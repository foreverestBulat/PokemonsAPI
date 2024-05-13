<script setup>
    import PokeMain from '../components/PokeMain.vue';
    import Breeding from '../components/Breeding.vue';
    import Loading from '../components/Loading.vue';
    import Moves from '../components/Moves.vue';
    import Abilities from '../components/Abilities.vue';
    import { RouterLink } from 'vue-router';
</script>

<template>    
    <div class="nav back">
        <div class="btn-back">
            <RouterLink to="/pokemons">
                back
            </RouterLink>
        </div>
    </div>    

    <div class="page-pokemon">
        <div v-if="details !== null" class="pokemon">
            <PokeMain :pokemon="details" percent="40" color="#000000"/>
            <Breeding :height="details.height" :weight="details.weight"/>
            <Moves :moves="details.moves"/>
            <Abilities :abilities="details.abilities"/>
        </div>
        <div v-else>
            <Loading />
        </div>
    </div>
    
    
</template>

<script>
    import { getPokemon } from '../services/api.service.js'

    export default {
        data () {
            return {
                details: null
            }
        },
        watch: {
            '$route.params.id': {
                immediate: true,
                async handler(id) {
                    this.details = await getPokemon(id);
                    console.log('DETAILS ---------------');
                    console.log(this.details.abilities);
                }
            }
        }
    }
</script>