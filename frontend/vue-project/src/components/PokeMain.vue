<script setup>
    import Stats from './Stats.vue';
</script>

<template>

    <div class="main-state child">
        <div class="name-id-types">
            <div class="name-id">
                <div class="id">#{{ pokemon.id }}</div>
                <div class="name">{{ pokemon.name }}</div>
            </div>
            <div>
                <div v-for="type in types" :style="{ backgroundColor: type.color, color: type.textcolor }">
                    <p>{{ type.name }}</p>
                </div>
            </div>
        </div>
        <div class="stats-image">
            <Stats :pokemon="pokemon"/>
            <div>
                <img :src="pokemon.image"/>
            </div>
        </div>
    </div>
    
</template>

<script>
    export default {
        props: {
            attackPer: {
                type: Number,
                default: 30
            },
            pokemon: {
                type: Object,
                default: null
            }
        }
    }

</script>